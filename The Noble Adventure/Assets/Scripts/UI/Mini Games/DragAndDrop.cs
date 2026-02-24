using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //Varibles Used
    public GameObject objectToDrag;
    public GameObject objectToDragPos;

    public float dragDistance;

    public bool isLocked;

    Vector2 objectInitialPos;

    //Spawning letters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*letters = GetComponent<Spawning>();
        foreach (GameObject letter in letters)
        {
            Debug.Log("hi");
        }*/

        //objectToDrag.transform.position.y = new Vector2(letterPos.letterRandomX, letterPos.letterRandomY);
        objectInitialPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
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
