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
    int i = 0;
    public bool questComplete;
    public GameObject nextText;

    GameObject collision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questComplete = false;
        if (nextText == null) return;
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
                nextText.gameObject.SetActive(false);
            }
        }
        else if (!questTask.activeInHierarchy)
        {
            questComplete = true;
        }
        
    }

    void LateUpdate()
    {
        NextQuest();
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
