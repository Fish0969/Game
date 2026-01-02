using Unity.VisualScripting;
using UnityEngine;

public class killer : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (enemy)
        {
            Debug.Log("You Died");
            Destroy(other.gameObject);
        }
    }
}
