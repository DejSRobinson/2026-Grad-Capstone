using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    // Loads in the game scene
    public void loadMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Loads in the game scene
    public void loadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Loads in the credit scene
    public void loadCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }

    // Quits the game
    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("You have quit the game!");
    }
}
