using UnityEngine;

public class InfoPostTrigger : MonoBehaviour
{
    [SerializeField] private TextDialogue infoPostTextDialogue;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        TextTrigger.TriggerText(infoPostTextDialogue);
    }
}
