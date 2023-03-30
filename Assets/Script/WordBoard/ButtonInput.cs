using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Adds a listener to a button and sends the letter within it to the output within a board panel.
/// </summary>
public class ButtonInput : MonoBehaviour
{
    // Button that attached to this script
    public Button button;

    // Name of the word board that is attached to this button
    public string wordBoardPanelName;

    /// <summary>
    /// Adds a listener to the buttons at the start of the game.
    /// </summary>
    void Start()
    {
        button.onClick.AddListener(InputButtonClick);
    }

    /// <summary>
    /// Gets the letter within the TMPro of the button and sends it to wordBoardPanel to be displayed in the output.
    /// </summary>
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
