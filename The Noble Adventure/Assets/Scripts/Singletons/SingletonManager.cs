using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonManger<T> : MonoBehaviour
{
    // A static reference to the single instance of the class
    public static SingletonManger<T> Instance { get; private set; }

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Otherwise, set this instance as the singleton instance
            Instance = this;
            // Optional: keep the object alive when loading new scenes
            // DontDestroyOnLoad(this.gameObject); 
        }
    }

    // Example method that can be accessed globally
    public void DisplayMessage(string message)
    {
        Debug.Log("Singleton Message: " + message);
    }
}
