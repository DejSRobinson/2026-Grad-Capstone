using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Variables Used
    public GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
