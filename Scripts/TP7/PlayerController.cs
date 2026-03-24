using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float stepSize = 1f;

    [Header("Collision")]
    [SerializeField] private LayerMask solidObjectsLayers;  // Walls + Obstacle

    [SerializeField] private LayerMask interactablesLayer;
    [SerializeField] private CircleCollider2D feetCollider; // drag le collider "pieds" ici dans l'inspector

    private bool isMoving;
    private Vector2 input;

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    public void handleUpdate()
    {
        if (isMoving) return;

        // Input (pas de diagonale)
        input = Vector2.zero;
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) input.y = 1;
            else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) input.y = -1;

            if (input.y == 0)
            {
                if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) input.x = -1;
                else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) input.x = 1;
            }
        }

        if (input != Vector2.zero) {
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);
        animator.SetBool("isMoving", true);
        }else{
            animator.SetBool("isMoving", false);
        }

        Vector2 targetPos = rb.position + input * stepSize;

        if (IsWalkable(targetPos))

            // StartCoroutine permet de lancer la fonction asynchrone (IEnumerator) qui s'exécute sur plusieurs frames. 
            // C'est ce qui permet de créer un déplacement fluide "case par case" au lieu d'une téléportation immédiate
            StartCoroutine(MoveTo(targetPos));
        else
            animator.SetBool("isMoving", false);


        if(keyboard.cKey.wasPressedThisFrame ){
            Interact();
        }
    }

    void Interact(){

        // Récupère la direction du regard
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        // Calcule la position de la case cible en ajoutant la direction à la position actuelle du joueur
        // C'est ici que sera placé le "radar" de détection
        var interactPost = transform.position + facingDir;


        // rayon du cercle de détection : 0,2
        // valeur assez petite pour ne pas détecter une interaction si notre personnage est trop loin

        var collider = Physics2D.OverlapCircle(interactPost, 0.2f, interactablesLayer);

        if(collider != null)
        {

            // Si le component associé au collider est de type Interactable, alors on lance la fonction Interact()
            collider.GetComponent<Interactable>()?.Interact();
        }
        
    }

    private IEnumerator MoveTo(Vector2 targetPos)
    {
        isMoving = true;
        animator.SetBool("isMoving", true);

        float timeout = 0.6f;
        float t = 0f;
        Vector2 lastPos = rb.position;

        while (Vector2.Distance(rb.position, targetPos) > 0.001f)
        {
             // tant que notre objet n'a pas atteint sa destination, on le déplace
            Vector2 nextPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(nextPos);

            // Suspend la coroutine pour laisser Unity afficher l'image actuelle, permettant ainsi un mouvement fluide et visible.
            yield return new WaitForFixedUpdate();

            t += Time.fixedDeltaTime;

            // bloqué (collision) -> stop
            if ((rb.position - lastPos).sqrMagnitude < 0.0000005f) break;
            lastPos = rb.position;

            if (t > timeout) break;
        }

        isMoving = false;
        animator.SetBool("isMoving", false);
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        if (feetCollider == null) return true;

        Vector2 start = rb.position;
        Vector2 dir = (targetPos - start).normalized;
        float dist = Vector2.Distance(start, targetPos);

        // On cast un cercle (les pieds) vers la case cible
        float radius = feetCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

        RaycastHit2D hit = Physics2D.CircleCast(
            start + (Vector2)feetCollider.offset,  // centre pieds
            radius,
            dir,
            dist,
            solidObjectsLayers
        );

        return hit.collider == null;
    }
}