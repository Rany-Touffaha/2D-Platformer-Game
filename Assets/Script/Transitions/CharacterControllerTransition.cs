using Gamekit2D;
using UnityEngine;

/// <summary>
/// This class controls the activation and deactivation of the main character's movement in the game.
/// </summary>
public class CharacterControllerTransition : MonoBehaviour
{

    public CharacterController2D characterController;

    /// <summary>
    /// Disables the main character's movement. 
    /// </summary>
    public void DisableCharacterController()
    {
        characterController = GameObject.Find("Ellen").GetComponent<CharacterController2D>();
        characterController.enabled = false;
    }

    /// <summary>
    /// Enables the main character's movement.
    /// </summary>
    public void EnableCharacterController()
    {
        characterController = GameObject.Find("Ellen").GetComponent<CharacterController2D>();
        characterController.enabled = true;
    }

}