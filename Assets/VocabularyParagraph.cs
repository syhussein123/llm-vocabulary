using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;


public class VocabularyParagraph : MonoBehaviour
{
    public TextMeshProUGUI paragraphText; // Reference to TextMeshPro component for the paragraph
    public VideoPlayer videoPlayer; // Reference to VideoPlayer for ASL signs

    public WordSelection wordSelectionScript; // Reference to the WordSelection script

    // Dictionary to hold vocabulary words and corresponding video URLs
    private Dictionary<string, string> vocabulary = new Dictionary<string, string>
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

    private List<string> selectedWords = new List<string>();
    private List<string> correctWords = new List<string>();

    void Start()
    {
        GenerateRandomParagraph();
    }

    void GenerateRandomParagraph()
    {
        List<string> allWords = new List<string>(vocabulary.Keys);
        for (int i = 0; i < 2; i++) // Pick 2 random words from the dictionary
        {
            int randomIndex = Random.Range(0, allWords.Count);
            string word = allWords[randomIndex];
            // Break up multi-word words into separate words
            string[] words = word.Split(' ');
            foreach (string word1 in words)
            {
                correctWords.Add(word1);
            }
            selectedWords.Add(allWords[randomIndex]);
            correctWords.Add(allWords[randomIndex]);
            allWords.RemoveAt(randomIndex); // Ensure no duplicate selections
        }

        // Create a paragraph using the selected words
        string paragraph = $"The {selectedWords[0]} is an important part of an {selectedWords[1]}.";
        paragraphText.text = paragraph;

        // Update the correct words in WordSelection script
        wordSelectionScript.correctWords = new List<string>(correctWords);
    }
}
