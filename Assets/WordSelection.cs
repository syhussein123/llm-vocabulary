using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class WordSelection : MonoBehaviour
{
    public TextMeshProUGUI paragraphText;  // TextMeshPro element for the paragraph
    public VideoPlayer videoPlayer;        // VideoPlayer to play ASL videos
    public List<string> correctWords = new List<string>();  // Use List<string> instead of string[]

    private Dictionary<string, string> vocabulary;  // Dictionary mapping words to video URLs

    void Start()
    {
        // Initialize vocabulary dictionary
        vocabulary = new Dictionary<string, string>
    {
        { "Cell", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/Cell_Corrected_Fingerspelled - Made with Clipchamp.mp4" },
        { "organism", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/food-web/Welcome to the Food Web/Sign Videos/Organism_Sign - Made with Clipchamp.mp4" },
        { "nucleus", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/Nucleus_Corrected_Fingerspelled - Made with Clipchamp.mp4" },
        { "DNA", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/DNA_Fingerspelled - Made with Clipchamp.mp4"},
        {"mitochondria", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Advanced Parts of the Cell/Sign Videos/Mitochondria_Sign - Made with Clipchamp.mp4"},
        {"cell", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/Cell_Corrected_Fingerspelled - Made with Clipchamp.mp4"},
        {"cell membrane", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/Cell_Membrane_Fingerspelled - Made with Clipchamp.mp4"},
        {"endoplasmic reticulum", "https://asl-aspire-videos-bucket-prod.s3.us-east-2.amazonaws.com/biology/parts-of-the-cell/Advanced+Parts+of+the+Cell/Sign+Videos/Endoplasmic_Reticulum_Sign+-+Made+with+Clipchamp.mp4"},
        {"golgi apparatus", "https://asl-aspire-videos-bucket-prod.s3.us-east-2.amazonaws.com/biology/parts-of-the-cell/Advanced+Parts+of+the+Cell/Sign+Videos/Golgi_Apparatus_Sign+-+Made+with+Clipchamp.mp4"},
        {"ribosomes", "https://asl-aspire-videos-bucket-prod.s3.amazonaws.com/biology/parts-of-the-cell/Basic Parts of the Cell/Sign Videos/Ribosome_Fingerspelled - Made with Clipchamp.mp4"},
    };

        // Subscribe to word click events
        paragraphText.ForceMeshUpdate();
    }

    void Update()
    {
        // Detect clicks on the TextMeshPro text
        if (Input.GetMouseButtonDown(0))
        {
            // Get the index of the character clicked
            int wordIndex = TMP_TextUtilities.FindIntersectingWord(paragraphText, Input.mousePosition, null);

            if (wordIndex != -1) // Valid word clicked
            {
                // Extract the clicked word
                string clickedWord = paragraphText.textInfo.wordInfo[wordIndex].GetWord();

                OnWordClicked(clickedWord);
            }
        }
    }

    // Function that is called when a word is clicked
    public void OnWordClicked(string clickedWord)
    {
        if (correctWords.Contains(clickedWord))
        {
            HighlightWord(clickedWord);  // Highlight the word
            PlayASLVideo(clickedWord);   // Play the ASL video for the word
        }
        else
        {
            ShowFeedback("The word you selected was " + clickedWord); // Show feedback for incorrect word
            ShowFeedback("The correct word was " + correctWords[0]); // Show feedback for incorrect word
            ShowFeedback("That's not the correct word!"); // Show feedback for incorrect word
        }
    }

    void HighlightWord(string word)
    {
        // Replace the clicked word in the TextMeshPro text with highlighted formatting
        paragraphText.text = paragraphText.text.Replace(word, $"<mark=#FFFF00>{word}</mark>");
    }

    void PlayASLVideo(string word)
    {
        if (vocabulary.ContainsKey(word))
        {
            Debug.Log("Playing video for " + word);
            Debug.Log(vocabulary[word]);
            videoPlayer.url = vocabulary[word];
            videoPlayer.Play(); // Play the ASL video associated with the word
        }
    }

    void ShowFeedback(string message)
    {
        Debug.Log(message);  // Simple feedback for now, can be expanded to UI feedback
    }
}
