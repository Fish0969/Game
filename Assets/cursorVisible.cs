using UnityEngine;

public class cursorVisible : MonoBehaviour
{
    public GameObject gameplay;
    void Start()
    {
    }

    void Update()
    {
        if (!gameplay.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (gameplay.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    
    }