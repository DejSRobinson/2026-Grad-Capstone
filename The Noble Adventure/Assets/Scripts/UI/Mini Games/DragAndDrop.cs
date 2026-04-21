using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectToDragPos;
    public float dragDistance;
    public bool isLocked;
    public Camera mainCamera;

    Vector2 objectInitialPos;
    private bool isDragging = false;
    /*
     * [HideInInspector]
    public bool isDragging = false;*/

    void Start()
    {
        objectInitialPos = objectToDrag.transform.position;

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            isDragging = true;
        }
    }

    void Update()
    {
        if (isDragging && !isLocked)
        {
            // Simple drag without offset (object center follows mouse)
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;
            objectToDrag.transform.position = mainCamera.ScreenToWorldPoint(mousePos);
        }
    }

    public void DropObject()
    {
        if (isDragging)
        {
            isDragging = false;

            float distance = Vector3.Distance(objectToDrag.transform.position, objectToDragPos.transform.position);

            if (distance < dragDistance)
            {
                isLocked = true;
                objectToDrag.transform.position = objectToDragPos.transform.position;
            }
            else
            {
                objectToDrag.transform.position = objectInitialPos;
            }
        }
    }
}