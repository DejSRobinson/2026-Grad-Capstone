using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //Varibles Used
    public bool IsShown { get; private set; }
    public string NPCId { get; private set; }

    //public Canvas[] textBox;
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
