using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gamekit2D;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private DialogueCanvasController dialogueCanvasController;

    private Queue<string> sentences = new Queue<string>();

    public void StartText(TextDialogue textDialogue)
    {
        Debug.Log($"Starting text containing { textDialogue.sentences.Count()} sentences");

        sentences.Clear();

        foreach (string sentence in textDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndText();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueCanvasController.ActivateCanvasWithText(sentence);
        Debug.Log(sentence);

        StartCoroutine(WaitForCanvasToDisplay(sentence));

    }

    private IEnumerator WaitForCanvasToDisplay(string sentence)
    {
        yield return new WaitForSeconds(3f);
        dialogueCanvasController.DeactivateCanvasWithDelay(1);
        DisplayNextSentence();
    }

    private void EndText()
    {
        Debug.Log("End of converstion");
    }
}
