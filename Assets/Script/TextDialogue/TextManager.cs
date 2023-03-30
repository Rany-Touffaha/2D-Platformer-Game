using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gamekit2D;
using UnityEngine;

/// <summary>
/// This class creates a queue data structure to include all the sentences from the TextDialogue variable and displays them whenever the TriggerText function is called.
/// It acts as an intermediary between the TextDialogue class and the TextTrigger class.
/// </summary>
public class TextManager : MonoBehaviour
{
    // This variable refers to the DialogueCanvasController script within the DialogueCanvas game object. 
    [SerializeField] private DialogueCanvasController dialogueCanvasController;

    // This creates a Queue data structure to store all the contents of the TextDialogue variable.
    private Queue<string> sentences = new Queue<string>();

    /// <summary>
    /// This function takes in a TextDialogue and adds it to the Queue.
    /// </summary>
    /// <param name="textDialogue">Text Dialogue variable that needs to be enqueued.</param>
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

    /// <summary>
    /// This function is called when the next sentence needs to be displayed on the dialogue canvas.
    /// </summary>
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

    /// <summary>
    /// Creates a delay in displaying the dialogue canvas using a coroutine to make sure the sentence is dequeued first before activating it.
    /// </summary>
    /// <param name="sentence">The sentence to be displayed on the dialogue canvas</param>
    /// <returns>A coroutine to make sure that the dialogue canvas is displayed before dequeuing the sentence</returns>
    private IEnumerator WaitForCanvasToDisplay(string sentence)
    {
        yield return new WaitForSeconds(3f);
        dialogueCanvasController.DeactivateCanvasWithDelay(2);
        DisplayNextSentence();
    }

    /// <summary>
    /// This function is called when the eveything has been dequeued and the text has ended.
    /// It only logs out "End of text" for now but can be expanded upon in the future. 
    /// </summary>
    private void EndText()
    {
        Debug.Log("End of text");
    }
}
