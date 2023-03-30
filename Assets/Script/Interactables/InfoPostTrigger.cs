using UnityEngine;

/// <summary>
/// This class triggers a the dialogue canvas whenver the character enters the collider of the game object that is attached to this script.
/// </summary>
public class InfoPostTrigger : MonoBehaviour
{
    // TextDialogue that contains the sentences whenever the character enters the infopost's space
    [SerializeField] private TextDialogue infoPostTextDialogue;

    /// <summary>
    /// Activates the TriggerText function for the infoPostTextDialogue to display it on the dialogue canvas.
    /// This function is called when an object enters the collider of the game object that is attached to this script.
    /// </summary>
    /// <param name="collider">Collider of the game object that has entered the collider of the game object that is attached to this script.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        TextTrigger.TriggerText(infoPostTextDialogue);
    }
}
