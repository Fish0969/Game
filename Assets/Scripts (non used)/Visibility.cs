using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Visibility : MonoBehaviour

{
        public RawImage optionsMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.enabled = !optionsMenu.enabled;
            if (optionsMenu.enabled)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
