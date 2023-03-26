using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WordBoard", menuName = "WordBoard")]
public class WordBoard : ScriptableObject
{

    public string word;
    public List<char> vowelLetters = new List<char>() { 'A', 'E', 'I', 'O', 'U', 'Y' };
    public List<char> consonantLetters;

    public Sprite wordImage;

    public void Print()
    {
        Debug.Log(word + ":" + string.Join(", ", consonantLetters) + ":" + string.Join(", ", vowelLetters));
    }

}
