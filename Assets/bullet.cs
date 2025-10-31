using System;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damagepoints;
    [SerializeField] Collider monkey;
    public void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Damage(damagepoints);
            
        }
        
    }
}
