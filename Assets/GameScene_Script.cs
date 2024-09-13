using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene_Script : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // Load the game scene (replace "MainMenu" with the name of your main menu scene)
        SceneManager.LoadScene("SampleScene");
    }
}
