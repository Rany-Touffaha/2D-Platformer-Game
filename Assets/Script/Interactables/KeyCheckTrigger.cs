using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckTrigger : MonoBehaviour
{
    [SerializeField] private KeyChecker keyChecker;
    [SerializeField] private GameObject door;
    [SerializeField] private TextDialogue insufficientKeysTextDialogue;
    [SerializeField] private TextDialogue winningTextDialogue;

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
