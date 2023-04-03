using UnityEngine;

/// <summary>
/// This class allows the user to create a an array of strings to form sectences.
/// Creating text dialogue objects makes it easier to display multiple sentences.
/// </summary>
[System.Serializable]
public class TextDialogue
{
    // This variable creates an array of strings to implement sentences.
    // The text area is simply to make it easier to write them within the inspector directly.
    [TextArea(2,5)]
    public string[] sentences;
}