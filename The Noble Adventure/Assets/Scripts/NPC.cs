using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }
    public string NPCId { get; private set; }

    public Canvas indicator;
    public Canvas[] textBox;
    public TextMeshProUGUI[] npcDialog;

    public QuestObjects questObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NPCId ??= GlobalHelper.GenerateUniqueID(gameObject);
        textBox[0].gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            textBox[0].gameObject.SetActive(true);
            indicator.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.E) && questObject.questComplete == true)
        {
            textBox[0].gameObject.SetActive(false);
            textBox[1].gameObject.SetActive(true);
        }
    }

    int index = 0;
    public void OnButtonClick()
    {
        if (index != (npcDialog.Length - 1))
        {
            npcDialog[index].gameObject.SetActive(false);
            npcDialog[index + 1].gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
        {
            SceneManager.LoadScene("GameSceneQuest2");
        }

        index++;
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
