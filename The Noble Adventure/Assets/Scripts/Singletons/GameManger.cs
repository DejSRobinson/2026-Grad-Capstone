using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : SingletonManger<GameManger>
{
    /// <summary>
    /// Used to transtion between scenes
    /// </summary>
    
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

    /// <summary>
    ///  Point and Click 
    /// </summary>
    /// 

    void Update()
    {
        Vector2 inputPos = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
        Debug.Log(inputPos);
    }
}
