using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanelController : MonoBehaviour
{

    [SerializeField] private GameObject firstWordPanel;
    [SerializeField] private GameObject secondWordPanel;
    [SerializeField] private GameObject thirdWordPanel;
    [SerializeField] private GameObject fourthWordPanel;
    [SerializeField] private GameObject fifthWordPanel;


    private GameObject[] panels;

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

    public void EnableWordPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public static void DisableWordPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}
