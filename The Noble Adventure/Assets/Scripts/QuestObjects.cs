using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestObjects : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }

    public Canvas indicator;
    public GameObject[] questTask;
    public Canvas complete;

    public bool questComplete;
    GameObject collision;
    private int currentQuestIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;

        if (currentQuestIndex < questTask.Length)
        {
            if (Input.GetKey(KeyCode.C))
            {
                if (collision != null && collision == gameObject)
                {
                    // Complete current quest
                    questTask[currentQuestIndex].SetActive(false);

                    currentQuestIndex++;

                    if (currentQuestIndex >= questTask.Length)
                    {
                        // All quests complete
                        indicator.gameObject.SetActive(false);
                        questComplete = true;
                        complete.gameObject.SetActive(true);
                        Invoke("close", 1.0f);
                    }
                    else
                    {
                        // Activate next quest
                        questTask[currentQuestIndex].SetActive(true);
                        Debug.Log($"Quest {currentQuestIndex + 1} started!");
                    }
                }
                else if (collision == null)
                {
                    Debug.Log("Nothing to collect - no object in range");
                }
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
