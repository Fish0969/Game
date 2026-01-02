using Unity.VisualScripting;
using UnityEngine;

public class killer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Died");
            Destroy(other.gameObject);
        }
    }
}
