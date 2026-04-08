using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRage = null;
    public Canvas interactionHint;
    public Canvas interactionItem;
    public Canvas textbox;
    public string ObjectId { get; private set; }

    public static GameObject hitObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionHint.gameObject.SetActive(false);
        interactionItem.gameObject.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactableInRage?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitObject = collision.gameObject;
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            if (collision.CompareTag("flowers"))
            {
                interactableInRage = interactable;
                interactionItem.gameObject.SetActive(true);
            }
            else
            {
                interactableInRage = interactable;
                interactionHint.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRage)
        {
            if (collision.CompareTag("flowers"))
            {

                interactableInRage = null;
                interactionItem.gameObject.SetActive(false);
            }
            else
            {
                interactableInRage = null;
                interactionHint.gameObject.SetActive(false);
                textbox.gameObject.SetActive(false);
            }
        }
    }
}
