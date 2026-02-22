using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    private bool isMoving;
    private Vector2 input;

    // update is called every time a frame is displayed
    private void Update()
    {
        // On ne fait rien si on est déjà en train de bouger
        if (isMoving) return;

        // Récupération des touches 
        input = Vector2.zero;
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) input.y = 1;
            else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) input.y = -1;
            
            if (input.y == 0) // empêche la diagonale
            {
                if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) input.x = -1;
                else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) input.x = 1;
            }
        }

        // Si une direction est pressée, on lance le mouvement
        if (input != Vector2.zero)
        {
            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            //StartCoruoutine permet de lancer la fonction asynchrone (IEnumerator) qui s'exécute sur plusieurs frames. 
            // C'est ce qui permet de créer un déplacement fluide "case par case" au lieu d'une téléportation immédiate
            StartCoroutine(Move(targetPos));
        }
    }


    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        //tant que notre objet n'a pas atteint sa destination, on le déplace
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){

            //MoveTorwards : déplace un point vers une cible, à une vitesse donnée
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);

            // Suspend la coroutine pour laisser Unity afficher l'image actuelle, permettant ainsi un mouvement fluide et visible.
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
    
}
