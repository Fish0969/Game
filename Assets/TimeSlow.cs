using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeSlow : MonoBehaviour
{
    public GameObject menu;
    public float staminaDrain;
    void Update()
    {
        if (!menu.activeSelf)
        
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = .2f;
                Debug.Log("Time slow");
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                Time.timeScale = 1;
                Debug.Log("Time slow stopped");
            }
        }
    }
}
