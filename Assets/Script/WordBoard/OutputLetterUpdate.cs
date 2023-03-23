using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutputLetterUpdate : MonoBehaviour
{
    public string word;
    public List<char> selectedLetters;
    public Button inputButton;
    public TextMeshPro outputText;

    public void getInputLetter()
    {
        TextMeshPro buttonText = inputButton.GetComponentInChildren<TextMeshPro>();
        string buttonString = buttonText.text;
        char letter = buttonString[0];
    }

    public void UpdateText(string buttonText)
    {
        outputText.text = buttonText;
    }
}
