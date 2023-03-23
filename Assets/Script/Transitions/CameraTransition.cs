using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera firstWordCamera;
    [SerializeField] private Camera secondWordCamera;
    [SerializeField] private Camera thirdWordCamera;

    private Camera[] cameras;

    private void Awake()
    {
        TransitionToMainCamera();
    }

    public void TransitionToMainCamera()
    {
        //Find the camera objects in the scene
        mainCamera = FindCamera("MainCamera");
        firstWordCamera = FindCamera("FirstWordCamera");
        secondWordCamera = FindCamera("SecondWordCamera");
        thirdWordCamera = FindCamera("ThirdWordCamera");

        cameras = new Camera[] { mainCamera, firstWordCamera, secondWordCamera, thirdWordCamera };

        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        mainCamera.enabled = true;
    }


    private Camera FindCamera(string cameraName)
    {
        GameObject cameraObject = GameObject.Find(cameraName);
        if (cameraObject == null)
        {
            Debug.LogError($"Could not find camera with name {cameraName}");
            return null;
        }
        return cameraObject.GetComponent<Camera>();
    }



    public void TransitionToCamera(Camera newCamera)
    {
        if (newCamera != null)
        {
            mainCamera.enabled = false;
            newCamera.enabled = true;
        }
        else
        {
            Debug.LogError("Camera with tag " + newCamera.ToString() + " not found.");
        }
    }

}
