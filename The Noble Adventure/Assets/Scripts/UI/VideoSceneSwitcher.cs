using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneSwitcher : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject button;

    void Start()
    {
        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the next scene by build index or name
        SceneManager.LoadScene("QuestOneScene");
    }
}

