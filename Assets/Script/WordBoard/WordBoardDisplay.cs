using System.Collections.Generic;
using Gamekit2D;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class links the scriptable object of the word to the elements of the word board panel.
/// Those elements include the input buttons, the output boxes and the image.
/// It also checks if the word is spelt properly and adjusts the game's interactables based on the result. 
/// </summary>
public class WordBoardDisplay : MonoBehaviour
{
    // Scriptable object that contains the word, the list of vowels, the list of consonants and the image.
    public WordBoard wordBoard;

    // Lists that point to the row of consonant letters' TMPro, the row of vowel letters' TMPro and the row of output letters' TMPro.
    public List<TextMeshPro> consonantLetterList;
    public List<TextMeshPro> vowelLetterList;
    public List<TextMeshPro> outputLetterList;

    // Variable that points to the image on the board
    public Image wordImage;

    // Variables that contain the pressure pad and key
    public PressurePad pressurePad;
    public InventoryItem key;

    // Variable that contains the incorrect 
    public TextDialogue incorrectWordTextDialogue;

    // Index that determines where is the next empty output box
    private int currentIndex = 0;

    /// <summary>
    /// Calls the function UpdateWordBoard at the start of the game
    /// </summary>
    private void Start()
    {
        UpdateWordBoard();
    }

    /// <summary>
    /// Updates the word board with all the elements from the scriptable object.
    /// This includes the row of consonant letters, the row of vowel letters and the word image.
    /// </summary>
    private void UpdateWordBoard()
    {
        wordBoard.Print();

        for (int i = 0; i < wordBoard.consonantLetters.Count && i < consonantLetterList.Count; i++)
        {
            consonantLetterList[i].text = wordBoard.consonantLetters[i].ToString();
        }

        for (int i = 0; i < wordBoard.vowelLetters.Count && i < vowelLetterList.Count; i++)
        {
            vowelLetterList[i].text = wordBoard.vowelLetters[i].ToString();
        }

        wordImage.sprite = wordBoard.wordImage;
    }

    /// <summary>
    /// Adds the letter of the input button to the output box of the current index
    /// </summary>
    /// <param name="letter">Letter that is taken from the TMPro of the input button</param>
    private void AddLetter(string letter)
    {
        if (currentIndex < outputLetterList.Count)
        {
            outputLetterList[currentIndex].text = letter;
            MoveToNextEmptyLetter();
        }
        else
        {
            CheckWord();
        }
    }

    /// <summary>
    /// Moves the current index into the next empty output box
    /// </summary>
    private void MoveToNextEmptyLetter()
    {
        currentIndex = outputLetterList.FindIndex(letter => string.IsNullOrEmpty(letter.text));
        if (currentIndex == -1)
        {
            currentIndex = outputLetterList.Count;
            AddLetter("");
        }
    }

    /// <summary>
    /// Checks if the word is correct upon filling in every single letter in the output boxes 
    /// </summary>
    private void CheckWord()
    {
        string word = wordBoard.word.ToUpper();
        bool isWordCorrect = true;

        for (int i = 0; i < word.Length && i < outputLetterList.Count; i++)
        {
            TextMeshPro outputLetter = outputLetterList[i];
            char wordChar = word[i];
            if (wordChar != outputLetter.text[0]) 
            {
                isWordCorrect = false;
                outputLetter.text = "";
            }
        }

        if (isWordCorrect)
        {
            // This TextDialogue is shown upon successful completion
            TextDialogue textDialogue = new TextDialogue
            {
                sentences = new[]
                {
                "Well Done!",
                }
            };

            // Disable the pressure pad and the word board, enable the key and show the winning text dialogue
            TextTrigger.TriggerText(textDialogue);
            DisablePressurePad();
            EnableKey();
            WordPanelController.DisableWordPanel(gameObject); 

            // Enable the character controller and transition to main camera
            GameObject ellen = GameObject.Find("Ellen");
            ellen.GetComponent<CharacterControllerTransition>().EnableCharacterController();
            ellen.GetComponent<CameraTransition>().TransitionToMainCamera();

        }
        else
        {
            // Shows the incorrect word text dialogue and moves index back to the next empty letter
            TextTrigger.TriggerText(incorrectWordTextDialogue);
            MoveToNextEmptyLetter();
        }
    }

    /// <summary>
    /// Disables the pressure pad game object
    /// </summary>
    void DisablePressurePad()
    {
        pressurePad.gameObject.SetActive(false); 
    }

    /// <summary>
    /// Enables the key upon completion
    /// </summary>
    void EnableKey()
    {
        key.gameObject.SetActive(true);
    }
}
