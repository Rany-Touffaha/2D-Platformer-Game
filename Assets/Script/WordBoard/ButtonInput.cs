using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInput : MonoBehaviour
{
    public Button button;
    public string wordBoardName;

    void Start()
    {
        button.onClick.AddListener(InputButtonClick);
    }

    private void InputButtonClick()
    {
        TextMeshPro buttonText = button.GetComponentInChildren<TextMeshPro>();
        string buttonString = buttonText.text;

        GameObject wordBoardPanel = GameObject.Find(wordBoardName);

        if (wordBoardPanel != null)
        {
            wordBoardPanel.SendMessage("AddLetter", buttonString);

        }

    }
}
