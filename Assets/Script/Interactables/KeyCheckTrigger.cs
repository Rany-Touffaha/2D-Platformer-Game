using UnityEngine;

/// <summary>
/// Triggers the key checker to check if the character has all the required keys 
/// </summary>
public class KeyCheckTrigger : MonoBehaviour
{
    // Checker to check if the character has all the required keys 
    [SerializeField] private KeyChecker keyChecker;

    // Door that is required to be opened
    [SerializeField] private GameObject door;

    // Text dialogue that would pop up if the character does not have the required keys
    [SerializeField] private TextDialogue insufficientKeysTextDialogue;

    // Text dialogue that would pop up if the character has the required keys
    [SerializeField] private TextDialogue winningTextDialogue;

    /// <summary>
    /// Opens the door when the character has all the required keys.
    /// Displays a winning text dialogue if the character has all the required keys, an insufficient keys dialogue otherwise.
    /// This function is called when an object enters the collider of the game object that is attached to this script.
    /// </summary>
    /// <param name="collider">Collider of the game object that has entered the collider of the game object that is attached to this script.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (keyChecker.CheckAllKeys())
        {
            door.GetComponent<Animator>().Play("DoorOpening");
            TextTrigger.TriggerText(winningTextDialogue);

        } else
        {
            TextTrigger.TriggerText(insufficientKeysTextDialogue);
        }
    }
}
