using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInput : MonoBehaviour
{
    public Button button;
    public string wordBoardPanelName;

    void Start()
    {
        button.onClick.AddListener(InputButtonClick);
    }

    private void InputButtonClick()
    {
        TextMeshPro buttonText = button.GetComponentInChildren<TextMeshPro>();
        string buttonString = buttonText.text;

        GameObject wordBoardPanel = GameObject.Find(wordBoardPanelName);

        if (wordBoardPanel != null)
        {
            wordBoardPanel.SendMessage("AddLetter", buttonString);

        }

    }
}
