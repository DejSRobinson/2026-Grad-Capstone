using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestObjects : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }

    public Canvas indicator;
    public GameObject questTask;
    public Canvas complete;

    public GameObject[] nextQuest;
    int i;
    public QuestObjects[] questObjects;
    public bool questComplete;

    GameObject collision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
        i = 0;
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;
        if (Input.GetKey(KeyCode.C))
        {
            if (collision != null && collision == gameObject)
            {
                questTask.gameObject.SetActive(false);
                indicator.gameObject.SetActive(false);
                complete.gameObject.SetActive(true);
                Invoke("close", 1.0f);

                //nextQuest[0].gameObject.SetActive(false);
                //nextQuest[1].gameObject.SetActive(true);
            }
        }

        if (questObjects != null && questObjects.Length > 1)
        {
            if (!questObjects[0].questTask.activeInHierarchy && !questObjects[1].questTask.activeInHierarchy && !questObjects[2].questTask.activeInHierarchy)
            {
                foreach (QuestObjects item in questObjects)
                {
                    item.questComplete = true;
                }
            }
        }
        else if (!questTask.activeInHierarchy)
        {
            questComplete = true;
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

    /*void NextQuest(int i)
    {
    }*/
}
