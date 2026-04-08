using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestObjects : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }
    public string ObjectId { get; private set; }

    public Canvas indicator;
    public GameObject questTask;
    public Canvas complete;

    public bool questComplete;
    GameObject collision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectId ??= GlobalHelper.GenerateUniqueID(gameObject);
        questComplete = false;
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;

        if (Input.GetKey(KeyCode.R))
        {
            if (collision != null && collision == gameObject)
            {
                questTask.SetActive(false);
                indicator.gameObject.SetActive(false);
                questComplete = true;

                complete.gameObject.SetActive(true);
                Invoke("close", 1.0f);
            }
            else if (collision == null)
            {
                Debug.Log("Nothing to collect - no object in range");
            }
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
