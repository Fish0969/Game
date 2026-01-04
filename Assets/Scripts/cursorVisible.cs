using UnityEngine;

public class cursorVisible : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject reset;
    void Start()
    {
        Timing();
    }
    public void Timing()
    {
        Time.timeScale = 1;
    }
    
    

    void Update()
    {
        if (!gameplay.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1;
        }
        if (gameplay.activeSelf)
        {
            if (!reset.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (gameplay.activeSelf)
        {
            if (reset.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    }


}