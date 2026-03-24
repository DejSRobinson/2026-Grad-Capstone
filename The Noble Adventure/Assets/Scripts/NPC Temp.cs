using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCTemp : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }
    public string NPCId { get; private set; }

    public Canvas indicator;
    public Canvas textBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NPCId ??= GlobalHelper.GenerateUniqueID(gameObject);
        textBox.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            textBox.gameObject.SetActive(true);
            indicator.gameObject.SetActive(false);
        }
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
