using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRage = null;
    //public GameObject interactionIcon;
    public Canvas interactionHint;
    public Canvas textbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //interactionIcon.SetActive(false);
        interactionHint.gameObject.SetActive(false);
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
        if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRage = interactable;
            //interactionIcon.SetActive(true);
            interactionHint.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRage)
        {
            interactableInRage = null;
            //interactionIcon.SetActive(false);
            interactionHint.gameObject.SetActive(false);
            textbox.gameObject.SetActive(false);
        }
    }
}
