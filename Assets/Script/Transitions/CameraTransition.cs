using UnityEngine;

/// <summary>
/// This class helps transition the viewpoint from the main character's camera to any of the other cameras within the game.
/// </summary>
public class CameraTransition : MonoBehaviour
{
    // Game objects of each of the cameras within the game
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera firstWordCamera;
    [SerializeField] private Camera secondWordCamera;
    [SerializeField] private Camera thirdWordCamera;
    [SerializeField] private Camera fourthWordCamera;
    [SerializeField] private Camera fifthWordCamera;

    // List of cameras within the game
    private Camera[] cameras;

    /// <summary>
    /// Calls the function TransitionToMainCamera at the start of the game
    /// </summary>
    private void Awake()
    {
        TransitionToMainCamera();
    }

    /// <summary>
    /// Finds all references of the cameras in the game, puts them in a list and deactivates all of them apart from the main camera.
    /// </summary>
    public void TransitionToMainCamera()
    {
        //Find the camera objects in the scene
        mainCamera = FindCamera("MainCamera");
        firstWordCamera = FindCamera("FirstWordCamera");
        secondWordCamera = FindCamera("SecondWordCamera");
        thirdWordCamera = FindCamera("ThirdWordCamera");
        fourthWordCamera = FindCamera("FourthWordCamera");
        fifthWordCamera = FindCamera("FifthWordCamera");

        cameras = new Camera[] { mainCamera, firstWordCamera, secondWordCamera, thirdWordCamera, fourthWordCamera, fifthWordCamera};

        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        mainCamera.enabled = true;
    }

    /// <summary>
    /// Finds the Camera within the game based on its name and returns its object.
    /// </summary>
    /// <param name="cameraName">Name of the camera that needs to be found</param>
    /// <returns>Camera object based on the input name</returns>
    private Camera FindCamera(string cameraName)
    {
        GameObject cameraObject = GameObject.Find(cameraName);
        if (cameraObject == null)
        {
            Debug.Log($"Could not find camera with name {cameraName}");
            return null;
        }
        return cameraObject.GetComponent<Camera>();
    }

    /// <summary>
    /// Transitions to the input camera by enabling it and disabling the main camera.
    /// </summary>
    /// <param name="newCamera">Input Camera object to be enabled</param>
    public void TransitionToCamera(Camera newCamera)
    {
        if (newCamera != null)
        {
            mainCamera.enabled = false;
            newCamera.enabled = true;
        }
        else
        {
            Debug.Log("Camera with tag " + newCamera.ToString() + " not found.");
        }
    }

}