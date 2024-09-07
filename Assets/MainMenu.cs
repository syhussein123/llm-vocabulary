using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be called when the "New Game" button is clicked
    public void NewGame()
    {
        // Load the game scene (replace "GameScene" with the actual scene name)
        SceneManager.LoadScene("GameScene");
    }
}
