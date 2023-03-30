using System.Collections;
using Gamekit2D;
using UnityEngine;

/// <summary>
/// This class allows the player to teleport upon clikcing the interact button.
/// This scripts needs to be attached to the main character game object.
/// </summary>
public class TeleportPlayer : MonoBehaviour
{
    // Teleport game object that was teleported to
    private Teleporter currentTeleporter;

    //Teleport game object that was teleported from 
    private Teleporter previousTeleporter;

    // Checks if the player is currently teleporting or not
    private bool isTeleporting = false;

    /// <summary>
    /// Checks if the player has pressed the interact button and is not currently teleporting.
    /// Start a teleport coroutine to transport the player.
    /// This function is called in every frame.
    /// </summary>
    private void Update()
    {
        if (PlayerInput.Instance.Interact.Down && currentTeleporter != null && currentTeleporter != previousTeleporter && !isTeleporting)
        {
            StartCoroutine(Teleport()); 
            previousTeleporter = currentTeleporter; 
        }
    }

    /// <summary>
    /// Gets the teleport script from the current game object to get the destination portal.
    /// This function is called when an object enters the collider of the game object that is attached to this script.
    /// </summary>
    /// <param name="collider">Collider of the game object that has entered the collider of the game object that is attached to this script.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter"))
        {
            currentTeleporter = collider.GetComponent<Teleporter>();
        }
    }

    /// <summary>
    /// Resets the current teleporter game object.
    /// This function is called when an object exits the collider of the game object that is attached to this script.
    /// </summary>
    /// <param name="collider">Collider of the game object that has entered the collider of the game object that is attached to this script.</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter") && collider.gameObject == currentTeleporter.gameObject)
        {
            currentTeleporter = null;
        }
    }

    /// <summary>
    /// Teleports the player using a coroutine to make sure the player isn't teleporting if the interact button is clicked again.
    /// </summary>
    /// <returns>A coroutine to make the character teleport.</returns>
    private IEnumerator Teleport()
    {
        isTeleporting = true;
        transform.position = currentTeleporter.GetDestinationPortal().position;
        yield return new WaitForSeconds(0);
        isTeleporting = false;
    }
}
