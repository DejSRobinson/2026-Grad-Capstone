using UnityEngine;

public class GamePause : MonoBehaviour
{
    /// <summary>
    /// A script that pauses the game for the pause menu
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            togglePause();
        }
    }


    void togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}