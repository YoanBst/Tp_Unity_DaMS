using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond = 40;

    public event Action onshowDialog;
    public event Action onHideDialog;

    public static DialogManager Instance { get; private set; }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();

        onshowDialog?.Invoke();

        this.dialog = dialog;
        currentLine = 0;
        dialogBox.SetActive(true);

        StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
    }
public void HandleUpdate()
{
    var keyboard = Keyboard.current;


    if ((keyboard.zKey.wasPressedThisFrame || keyboard.spaceKey.wasPressedThisFrame) && !isTyping)
    {

        currentLine++;

        if (currentLine < dialog.Lines.Count)
        {
            StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
        }
        else
        {
            dialogBox.SetActive(false);
            currentLine = 0;
            dialog = null;

            onHideDialog?.Invoke();
        }
    }
}
public IEnumerator TypeDialog(string line)
{

    isTyping = true;
    dialogText.text = "";

    float delay = 1f / Mathf.Max(lettersPerSecond, 1);

    foreach (char letter in line)
    {
        dialogText.text += letter;


        yield return new WaitForSeconds(delay);
    }

    isTyping = false;

}
}