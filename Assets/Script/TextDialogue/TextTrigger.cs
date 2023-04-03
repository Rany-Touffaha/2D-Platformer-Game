using UnityEngine;

/// <summary>
/// This class is used to trigger the DialogueCanvas within the game and display the TextDialogue sentences.
/// It can be attached to a game object as a script or be triggered directly within the code of the game.
/// </summary>
public class TextTrigger : MonoBehaviour
{
    [SerializeField] private TextDialogue textDialogue;

    /// <summary>
    /// Triggers the TextManager to display the TextDialogue that is included in this class on the DialogueCanvas.
    /// </summary>
    public void TriggerText()
    {
        FindObjectOfType<TextManager>().StartText(this.textDialogue);
    }

    /// <summary>
    /// Triggers the TextManager to display the input TextDialogue on the DialogueCanvas.
    /// The function is static so that it can be called anywhere within the code of the game. 
    /// </summary>
    /// <param name="textDialogue">TextDialogue to be displayed on the DialogueCanvas</param>
    public static void TriggerText(TextDialogue textDialogue)
    {
        FindObjectOfType<TextManager>().StartText(textDialogue);
    }

}