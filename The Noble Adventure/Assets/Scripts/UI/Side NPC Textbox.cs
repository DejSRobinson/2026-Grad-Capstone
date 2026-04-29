using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCTemp : MonoBehaviour, IInteractable
{
    public bool IsShown { get; private set; }
    public Canvas indicator;
    public Canvas textBox;

    GameObject collision;
    private bool isTextBoxOpen = false;

    void Start()
    {
        textBox.gameObject.SetActive(false);
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;

        if (Input.GetKeyDown(KeyCode.E) && collision == gameObject && !isTextBoxOpen)
        {
            textBox.gameObject.SetActive(true);
            indicator.gameObject.SetActive(false);
            isTextBoxOpen = true;
            Invoke("close", 3.0f);
        }
    }

    void close()
    {
        textBox.gameObject.SetActive(false);
        isTextBoxOpen = false;
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