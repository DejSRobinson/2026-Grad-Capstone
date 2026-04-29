using EasyTextEffects.Editor.MyBoxCopy.Extensions;
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
    public TextMeshProUGUI nextHint;

    public QuestObjects[] questObjects;
    public bool questComplete;
    public GameObject nextText;

    public GameObject[] collected;
    GameObject collision;


    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
        if (nextText == null) return;
    }

    void CompleteQuest()
    {
        // Handle UI
        questTask.gameObject.SetActive(false);
        indicator.gameObject.SetActive(false);
        complete.gameObject.SetActive(true);

        // Close UI after delay
        Invoke("close", 1.0f);
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;
        if (Input.GetKey(KeyCode.C))
        {
            if (collision != null && collision == gameObject)
            {
                CompleteQuest(); // Call everything here once
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
                if (nextText == null) return;
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

    void LateUpdate()
    {
        NextQuest();
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (i == 1)  // Currently on first quest
            {
                nextQuest[0].gameObject.SetActive(false);
                nextQuest[1].gameObject.SetActive(true);
            }
            else if (i == 0)  // Currently on second quest
            {
                nextHint.gameObject.SetActive(false);
                nextQuest[0].gameObject.SetActive(true);
                i = 1;
            }
        }
    }
}
