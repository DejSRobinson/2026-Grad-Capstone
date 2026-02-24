using UnityEngine;
using UnityEngine.SceneManagement; // Required for SceneManager

public class TempSceneLoader : MonoBehaviour
{

    public void Grammer()
    {
        SceneManager.LoadScene("Grammer");
    }

    public void DragAndDrop()
    {
        SceneManager.LoadScene("DragAndDrop");
    }

    public void Animation()
    {
        SceneManager.LoadScene("Animation");
    }
}
