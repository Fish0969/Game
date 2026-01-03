using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeSlow : MonoBehaviour
{
    public GameObject menu;
    public float staminaDrain;
    void Update()
    {
        staminaDrain = (gameObject.GetComponent<MoveScript>().CurrentStamina);
        if (!menu.activeSelf)
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = .2f;
        }
    }
}
