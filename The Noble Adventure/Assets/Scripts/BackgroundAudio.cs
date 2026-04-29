using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    private static BackgroundAudio instance;

    void Awake()
    {
        // Singleton pattern: if an instance already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // Keeps the object alive across scene transitions
        DontDestroyOnLoad(gameObject);
    }
}
