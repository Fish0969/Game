using UnityEngine;

public class enemydamageplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealth playerHealth;
    public void Attack()
    {
        playerHealth.TakeDamage(10);

    }
}
