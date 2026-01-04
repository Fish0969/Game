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
            while (Input.GetKey(KeyCode.F))
            {
                Time.timeScale = .2f;
                Debug.Log("Time slow");
            }
        }
    }
}
