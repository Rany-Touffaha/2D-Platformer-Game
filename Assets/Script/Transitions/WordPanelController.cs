using UnityEngine;

/// <summary>
/// This class controls the activation and deactivation of the word panel objects in the game.
/// </summary>
public class WordPanelController : MonoBehaviour
{
    // Game objects of each of the word panels within the game
    [SerializeField] private GameObject firstWordPanel;
    [SerializeField] private GameObject secondWordPanel;
    [SerializeField] private GameObject thirdWordPanel;
    [SerializeField] private GameObject fourthWordPanel;
    [SerializeField] private GameObject fifthWordPanel;

    // List of game objects that contain all the panels
    private GameObject[] panels;

    /// <summary>
    /// Finds all references of the word panel game objects, puts them in a list and deactivates all of them.
    /// This function is called immediately before the start of the game.  
    /// </summary>
    void Awake()
    {

        firstWordPanel = GameObject.Find("FirstWordPanel");
        secondWordPanel = GameObject.Find("SecondWordPanel");
        thirdWordPanel = GameObject.Find("ThirdWordPanel");
        fourthWordPanel = GameObject.Find("FourthWordPanel");
        fifthWordPanel = GameObject.Find("FifthWordPanel");

        panels = new GameObject[] { firstWordPanel, secondWordPanel, thirdWordPanel, fourthWordPanel, fifthWordPanel };

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    /// <summary>
    /// Enables the word panel object in the game
    /// </summary>
    /// <param name="panel">Word panel object that needs to be enabled</param>
    public void EnableWordPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    /// <summary>
    /// Disables the word panel object in the game
    /// </summary>
    /// <param name="panel">Word panel object that needs to be disabled</param>
    public static void DisableWordPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}