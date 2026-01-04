using Unity.VisualScripting;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
     public Transform maincamera;
    public  Transform Buttons;
    public Transform canvas;
    public Vector3 offset ;

    void Start()
    {
        maincamera = Camera.main.transform;
        Buttons = transform.parent;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        transform.SetParent(canvas); 
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - maincamera.position);
        transform.position = Buttons.position + offset;
    }
}
