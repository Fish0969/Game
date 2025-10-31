using UnityEngine;

public class enemydamageplayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public void Attack()
    {
        playerHealth.TakeDamage(10);

    }
}
