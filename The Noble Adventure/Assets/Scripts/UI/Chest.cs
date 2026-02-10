using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour, IInteractable
{

    public bool IsOpened {  get; private set; }
    //public string ChestID { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);
    }

    public bool CanInteract()
    {
        return !IsOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        //OpenChest();
    }

    /*
    private void OpenChest()
    {
        //IsOpened = true;
        SetOpend(true);
    }

    public void SetOpend(bool opened)
    {
        if(IsOpened)
        {
            Debug.Log("I'm opened!");
        }
    }*/
}
