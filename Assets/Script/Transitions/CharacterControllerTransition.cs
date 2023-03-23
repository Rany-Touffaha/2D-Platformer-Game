using System.Collections;
using System.Collections.Generic;
using Gamekit2D;
using UnityEngine;

public class CharacterControllerTransition : MonoBehaviour
{

    public CharacterController2D characterController;

    public void DisableCharacterController()
    {
        characterController = GameObject.Find("Ellen").GetComponent<CharacterController2D>();
        characterController.enabled = false;
    }

    public void EnableCharacterController()
    {
        characterController = GameObject.Find("Ellen").GetComponent<CharacterController2D>();
        characterController.enabled = true;
    }

}
