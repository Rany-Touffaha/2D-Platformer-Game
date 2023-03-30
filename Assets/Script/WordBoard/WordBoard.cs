using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This creates a scriptable object where you can store the word, the vowel letters and the consonant letters
/// </summary>
[CreateAssetMenu(fileName = "New WordBoard", menuName = "WordBoard")]
public class WordBoard : ScriptableObject
{
    // Variables that contain the word, the list of vowels and the list of consonants
    public string word;
    public List<char> vowelLetters = new List<char>() { 'A', 'E', 'I', 'O', 'U', 'Y' };
    public List<char> consonantLetters;

    // Variable that contains the image of the word
    public Sprite wordImage;

    /// <summary>
    /// Print out the word, the consonant letters and the vowel letters for debugging purposes
    /// </summary>
    public void Print()
    {
        Debug.Log(word + ":" + string.Join(", ", consonantLetters) + ":" + string.Join(", ", vowelLetters));
    }

}
