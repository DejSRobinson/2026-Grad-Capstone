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

    public QuestObjects[] questObjects;
    int index = 1;
    public bool questComplete;

    GameObject collision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
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

                //Where else could I call this? This throws and error
                //NextQuest();
            }
        }

        //How do I check to see if the "Glow" is active or not
        if (questObjects != null && questObjects.Length > 1)
        {
            if (!questObjects[0].questTask.activeInHierarchy && !questObjects[1].questTask.activeInHierarchy && !questObjects[2].questTask.activeInHierarchy)
            {
                foreach(QuestObjects item in questObjects)
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

    void NextQuest()
    {
        //Why are you always an error?
        /*
        nextQuest[index].gameObject.SetActive(false);
        index += 1;
        nextQuest[index].gameObject.SetActive(true);*/
    }
}
