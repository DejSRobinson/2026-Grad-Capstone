using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameSloved : MonoBehaviour
{
    public DragAndDrop[] lettersSolved;
    public GameObject message;
    public GameObject button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //message.gameObject.SetActive(false);
        //button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( message != null && button != null)
        {
            if (lettersSolved.All(item => item.isLocked))
            {
                message.gameObject.SetActive(true);
                button.gameObject.SetActive(true);
            }
        }
        else
        {
            if (lettersSolved.All(item => item.isLocked))
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
