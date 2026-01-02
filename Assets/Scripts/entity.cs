using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class entity : MonoBehaviour
{
    // public UnityEvent DamagePlayer;
    [SerializeField] private HPScript _healthbar;
    [SerializeField] private float StartingHealth;
    public int enemiesKilled;
    public TextMeshProUGUI enemiesKilledTMP;
    public float health;
    public float Health

    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            // Debug.Log(health);
            _healthbar.UpdateHealthBar(StartingHealth, health);

            if (health <= 0f)
            {
                Destroy(gameObject);
                
            }

        }
    }
    void Start()
    {
        enemiesKilled = 0;
        health = StartingHealth;
        _healthbar.UpdateHealthBar(StartingHealth, health);
    }

    // public void Dead()
    // {
    //     Destroy(gameObject);
    // }
}
