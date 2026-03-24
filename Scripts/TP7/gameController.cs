using UnityEngine;


public enum GameState {freeRoam , dialog}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state ;

    private void Start()
    {
        DialogManager.Instance.onshowDialog += () =>
        {
            state = GameState.dialog;

        } ;
        DialogManager.Instance.onHideDialog += () =>
        {   if ( state == GameState.dialog)
            state = GameState.freeRoam;

        } ;
    }

    private void Update()
    {
        if (state == GameState.freeRoam)
        {
            playerController.handleUpdate();

        }else if (state == GameState.dialog)
        {
            DialogManager.Instance.HandleUpdate();

        }
    }
}
