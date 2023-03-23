using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private TextDialogue textDialogue;

    public void TriggerText()
    {
        FindObjectOfType<TextManager>().StartText(this.textDialogue);
    }

    public static void TriggerText(TextDialogue textDialogue)
    {
        FindObjectOfType<TextManager>().StartText(textDialogue);
    }

}
