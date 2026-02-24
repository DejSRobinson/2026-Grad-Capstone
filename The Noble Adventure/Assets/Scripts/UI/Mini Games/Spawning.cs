using UnityEngine;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    public static List<GameObject> allLetters = new List<GameObject>();

    void Awake()
    {
        // Clear the list when the game starts
        allLetters.Clear();
    }

    void Start()
    {
        // Add this letter to the static list
        allLetters.Add(gameObject);
    }
}
