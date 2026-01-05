using System;
using TMPro;
using UnityEngine;

public class StatsChange : MonoBehaviour
{
#region GameObjects
[Header("GameObjects")]
public GameObject Player;
public GameObject Fred;
public GameObject Bob;
public GameObject Mate;
public GameObject enemy;  
public GameObject Scripts;  

#endregion
#region Weapons
[Header("Weapons")]
private GameObject Weapon;
public GameObject Gun;
public GameObject Laser;
#endregion
#region PlayerStats
[Header("Player Stats")]
public TextMeshProUGUI WalkCurrent;
public TextMeshProUGUI RunCurrent;
public TextMeshProUGUI DamageCurrent;
public TextMeshProUGUI HealthCurrent;
public TextMeshProUGUI StaminaCurrent;
public TextMeshProUGUI StaminaDrainCurrent;
#endregion
#region EnemyStats
[Header("Enemy Stats")]
public TextMeshProUGUI EnemyWalkCurrent;
public TextMeshProUGUI EnemyDamageCurrent;
public TextMeshProUGUI EnemyHealthCurrent;
public TextMeshProUGUI EnemyAttackSpeedCurrent;
public TextMeshProUGUI EnemyAttackRangeCurrent;
public TextMeshProUGUI WaveOfEnemiesCurrent;
#endregion

    void Update()
    {   


        #region IF

        if (Fred.activeSelf)
        {
            Player = Fred;
            //Weapon = Laser;
            DamageCurrent.text = Laser.GetComponent<DamageGun>().Damage.ToString();
        }

        if (Bob.activeSelf)
        {
            Player = Bob;
            //Weapon = Gun;
            DamageCurrent.text = Gun.GetComponent<DamageGun>().Damage.ToString();
        }

        if (Mate.activeSelf)
        {
            Player = Mate;
        }
        #endregion
        #region PlayerStats
        WalkCurrent.text = Player.GetComponent<MoveScript>().walkingSpeed.ToString();
        RunCurrent.text = Player.GetComponent<MoveScript>().runningSpeed.ToString();
        HealthCurrent.text = Player.GetComponent<Health>().maxPlayerHealth.ToString();
        StaminaCurrent.text = Player.GetComponent<MoveScript>().MaxStamina.ToString();
        StaminaDrainCurrent.text = Player.GetComponent<MoveScript>().ChargeRate.ToString();
        #endregion
        #region EnemyStats
        EnemyWalkCurrent.text = enemy.GetComponent<enemylookingplayer>().speed.ToString();
        EnemyDamageCurrent.text = enemy.GetComponent<enemylookingplayer>().damageAmount.ToString();
        EnemyHealthCurrent.text = enemy.GetComponent<entity>().StartingHealth.ToString();
        EnemyAttackSpeedCurrent.text = enemy.GetComponent<enemylookingplayer>().attackInterval.ToString();
        EnemyAttackRangeCurrent.text = enemy.GetComponent<enemylookingplayer>().detectionRadius.ToString();
        WaveOfEnemiesCurrent.text = enemy.GetComponent<GeneratingEnemies>().maxEnemyCount.ToString();
        #endregion

        
        
    }
}
