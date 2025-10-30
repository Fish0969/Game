using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class entity : MonoBehaviour
{
    [SerializeField] private HPScript _healthbar;
    [SerializeField] private float StartingHealth;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            Debug.Log(health);
            _healthbar.UpdateHealthBar(StartingHealth, health);


            if (health <= 0f)
            {
                Destroy(gameObject);
            }

        }
    }
    void Start()
    {
        Health = StartingHealth;
        _healthbar.UpdateHealthBar(StartingHealth, health);
    }
}
