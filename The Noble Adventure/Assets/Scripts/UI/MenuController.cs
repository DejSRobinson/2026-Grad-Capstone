using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    // Variables Used
    public GameObject pauseMenu;
    public GameObject hint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (hint != null && pauseMenu != null)
        {
            hint.gameObject.SetActive(true);
            Invoke("close", 1.5f);
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

    void close()
    {
        hint.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("QuestOneScene");
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
