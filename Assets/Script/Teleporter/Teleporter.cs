using UnityEngine;

/// <summary>
/// This class stores the destination portal object to teleport the player.
/// It is called upon by the TeleportPlayer class.  
/// The script should be attached to a teleporter game object to work.
/// </summary>
public class Teleporter : MonoBehaviour
{
    // Stores the transform position of the destination portal 
    [SerializeField] private Transform destinationPortal;

    /// <summary>
    /// This function returns the transform position of the destination portal.
    /// </summary>
    /// <returns>Transform position of the destination portal</returns>
    public Transform GetDestinationPortal()
    {
        return destinationPortal;
    }
}
