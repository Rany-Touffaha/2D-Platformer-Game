using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform destinationPortal;

    //Returns the transform of the destination portal
    public Transform GetDestinationPortal()
    {
        return destinationPortal;
    }

}
