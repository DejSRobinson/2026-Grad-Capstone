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
    public TextMeshProUGUI[] npcDialog2;

    public QuestObjects[] questObject;
    GameObject collision;

    void Start()
    {
        textBox[0].gameObject.SetActive(false);
    }
    void Update()
    {
        collision = InteractionDetector.hitObject;
        if (Input.GetKey(KeyCode.E) && collision == gameObject)
        {
            if (textBox[0] == null)
            {
                textBox[1].gameObject.SetActive(true);
                indicator.gameObject.SetActive(false);
            }
            else
            {
                textBox[0].gameObject.SetActive(true);
                indicator.gameObject.SetActive(false);
            }
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
                for (int i = 1; i < questObject.Length; i++)
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
                for (int i = 1; i < questObject.Length; i++)
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

    public void TextClose()
    {
        textBox[1].gameObject.SetActive(false);
    }

    int index = 0;
    public void StartMiniGame()
    {
        textBox[0].gameObject.SetActive(false);
        textBox[1].gameObject.SetActive(true);
        textBox.RemoveAt(0);
        Destroy(textBox[0].gameObject);
    }
    public void OnButtonClickFirst()
    {
        if (index != (npcDialog.Length - 1))
        {
            npcDialog[index].gameObject.SetActive(false);
            npcDialog[index + 1].gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestTwoScene"))
        {
            SceneManager.LoadScene("QuestThreeScene");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestOneScene"))
        {
            SceneManager.LoadScene("QuestTwoScene");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestThreeScene"))
        {
            SceneManager.LoadScene("CreditScene");
        }

        index++;
    }

    public void OnButtonClickTwo()
    {
        if (index != (npcDialog2.Length - 1))
        {
            npcDialog2[index].gameObject.SetActive(false);
            npcDialog2[index + 1].gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestTwoScene"))
        {
            SceneManager.LoadScene("QuestThreeScene");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestOneScene"))
        {
            SceneManager.LoadScene("QuestTwoScene");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QuestThreeScene"))
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
