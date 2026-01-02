using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class entity : MonoBehaviour
{
    public UnityEvent DamagePlayer; 
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

        health = StartingHealth;
        _healthbar.UpdateHealthBar(StartingHealth, health);
    }

}
