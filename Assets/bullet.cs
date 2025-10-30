using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float timetilldestroyed;
    void Awake()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        
        
    }
}
