using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }

    public Canvas indicator;
    public Canvas[] textBox;
    public TextMeshProUGUI[] npcDialog;

    public QuestObjects[] questObject;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            textBox[0].gameObject.SetActive(true);
            indicator.gameObject.SetActive(false);
        }

        if (questObject.Length == 1)
        {
            if (Input.GetKey(KeyCode.E) && questObject[0].questComplete == true)
            {
                textBox[1].gameObject.SetActive(false);
                textBox[2].gameObject.SetActive(true);
            }
        }
        else
        {
            if (questObject.Length > 1)
            {
                for (int i = 0; i < questObject.Length; i++)
                {
                    if (Input.GetKey(KeyCode.E) && questObject[i].questComplete == true)
                    {
                        textBox[1].gameObject.SetActive(false);
                        textBox[2].gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < questObject.Length; i++)
                {
                    if (Input.GetKey(KeyCode.E) && questObject[i].questComplete == true)
                    {
                        textBox[1].gameObject.SetActive(false);
                        textBox[2].gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    int index = 0;
    public void StartMiniGame()
    {
        textBox[0].gameObject.SetActive(false);
        textBox[1].gameObject.SetActive(true);
        textBox.RemoveAt(0);
        Destroy(textBox[0].gameObject);
    }

    public void OnButtonClick()
    {
        if (index != (npcDialog.Length - 1))
        {
            npcDialog[index].gameObject.SetActive(false);
            npcDialog[index + 1].gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestOneScene"))
        {
            SceneManager.LoadScene("QuestTwoScene");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestTwoScene"))
        {
            SceneManager.LoadScene("CreditScene");
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
