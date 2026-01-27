using System.ComponentModel.Design;
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
    ///  Point and Click Logic 
    /// </summary>
    /// 

    // Varaibles used
    private Vector2 m_InitalTouchPos;
    public PlayerMovement m_player;

    void Update()
    {
        Vector2 inputPos = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            DetectClick(inputPos);
        }

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (Vector2.Distance(m_InitalTouchPos, inputPos) < 10) DetectClick(inputPos);
        }
    }

    void DetectClick(Vector2 inputPos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(inputPos);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        m_player.MoveTo(worldPoint);
    }
}
