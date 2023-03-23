using Gamekit2D;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private Teleporter currentTeleporter;

    private void Update()
    {

        if (PlayerInput.Instance.Interact.Down && currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetDestinationPortal().position;
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
}
