using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCTemp : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }

    public Canvas indicator;
    public Canvas textBox;

    GameObject collision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.gameObject.SetActive(false);
    }

    void Update()
    {
        collision = InteractionDetector.hitObject;
        if (Input.GetKey(KeyCode.E) && collision == gameObject)
        {
            textBox.gameObject.SetActive(true);
            indicator.gameObject.SetActive(false);
        }
        Invoke("close", 6.0f);
    }
    void close()
    {
        textBox.gameObject.SetActive(false);
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
