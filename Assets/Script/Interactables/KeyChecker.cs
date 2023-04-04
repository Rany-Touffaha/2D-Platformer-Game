using Gamekit2D;
using UnityEngine;
using static Gamekit2D.InventoryController;

/// <summary>
/// This class takes the inventory of the character and checks if it has all the required keys in it.
/// </summary>
public class KeyChecker : MonoBehaviour
{
    // Inventory of the objects that is attached to the main character
    [SerializeField] private InventoryController inventoryController;

    // Checker of what is contained in the InventoryController
    [SerializeField] private InventoryChecker checker = new InventoryChecker();

    // List of keys that are needed to open the final door.
    [SerializeField] private string[] requiredKeys = { "Key1", "Key2", "Key3", "Key4", "Key5" };

    /// <summary>
    /// Checks if the inventory has all the required keys. 
    /// </summary>
    /// <returns>True if the character has all the requried keys, false otherwise.</returns>
    public bool CheckAllKeys()
    {
        if (inventoryController == null)
        {
            Debug.Log("InventoryController is null");
            return false;
        }

        if (requiredKeys == null || requiredKeys.Length == 0)
        {
            Debug.Log("Required keys array is null or empty");
            return false;
        }

        checker.inventoryItems = requiredKeys;
        bool hasAllKeys = checker.CheckInventory(inventoryController);
        return hasAllKeys;
    }
}