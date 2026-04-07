using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestObject2 : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }

    public Canvas indicator;
    public GameObject questTask;
    public Canvas complete;

    public bool questComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            questTask.SetActive(false);
            indicator.gameObject.SetActive(false);
            questComplete = true;

            complete.gameObject.SetActive(true);
            Invoke("close", 1.0f);
        }
    }

    void close()
    {
        complete.gameObject.SetActive(false);
    }

    public bool CanInteract()
    {
        return !IsShown;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
    }
}
