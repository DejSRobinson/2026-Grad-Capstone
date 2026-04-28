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

    public GameObject[] nextGame;
    public static int indexTextbox;

    void Start()
    {
        textBox[0].gameObject.SetActive(false);
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;
        indexTextbox = textBox.Length;

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

    int indexOne = 0;
    int indexTwo = 0;
    int indexThree = 0;

    public void StartMiniGame()
    {
        textBox[0].gameObject.SetActive(false);
        textBox[1].gameObject.SetActive(true);
        textBox.RemoveAt(0);
        Destroy(textBox[0].gameObject);
    }
    public void OnButtonClick()
    {
        if (indexOne != (npcDialog.Length - 1))
        {
            npcDialog[indexOne].gameObject.SetActive(false);
            npcDialog[indexOne + 1].gameObject.SetActive(true);
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

        indexOne++;
    }

    public void OnButtonClickFirst()
    {
        if (indexTwo != (npcDialog.Length - 1))
        {
            npcDialog[indexTwo].gameObject.SetActive(false);
            npcDialog[indexTwo + 1].gameObject.SetActive(true);
        }
        else
        {
            textBox[1].gameObject.SetActive(false);
            nextGame[0].gameObject.SetActive(false);
            nextGame[1].gameObject.SetActive(true);
        }

        indexTwo++;
    }

    public void OnButtonClickTwo()
    {
        if (indexThree != (npcDialog.Length - 1))
        {
            npcDialog2[indexThree].gameObject.SetActive(false);
            npcDialog2[indexThree + 1].gameObject.SetActive(true);
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

        indexThree++;
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
