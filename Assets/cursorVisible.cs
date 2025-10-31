using UnityEngine;

public class cursorVisible : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject characterchoser;
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
    }

    
    }