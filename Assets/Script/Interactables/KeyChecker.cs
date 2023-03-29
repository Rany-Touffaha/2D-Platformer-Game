using Gamekit2D;
using UnityEngine;
using static Gamekit2D.InventoryController;

public class KeyChecker : MonoBehaviour
{

    [SerializeField] private InventoryController inventoryController;
    [SerializeField] private InventoryChecker checker = new InventoryChecker();
    [SerializeField] private string[] requiredKeys = { "Key1", "Key2", "Key3", "Key4", "Key5" };

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
        Debug.Log(hasAllKeys);
        return hasAllKeys;
    }

}
