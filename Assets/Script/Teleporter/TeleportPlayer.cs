using System.Collections;
using Gamekit2D;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private Teleporter currentTeleporter;
    private Teleporter previousTeleporter;
    private bool isTeleporting = false;

    private void Update()
    {
        if (PlayerInput.Instance.Interact.Down && currentTeleporter != null && currentTeleporter != previousTeleporter && !isTeleporting)
        {
            StartCoroutine(Teleport()); 
            previousTeleporter = currentTeleporter; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter"))
        {
            currentTeleporter = collider.GetComponent<Teleporter>();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter") && collider.gameObject == currentTeleporter.gameObject)
        {
            currentTeleporter = null;
        }
    }

    private IEnumerator Teleport()
    {
        isTeleporting = true;
        transform.position = currentTeleporter.GetDestinationPortal().position;
        yield return new WaitForSeconds(0);
        isTeleporting = false;
    }
}
