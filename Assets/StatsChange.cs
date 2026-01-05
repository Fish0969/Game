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

#region OriginalPlayerStats
private float originalWalk;
private float originalRun;
private float originalDamage;
private float originalHealth;
private float originalStamina;
private float originalStaminaDrain;
#endregion
#region OriginalEnemyStats
public float EnemyOriginalWalk;
public float EnemyOriginalDamage;
public float EnemyOriginalHealth;
public float EnemyOriginalAttackSpeed;
public float EnemyOriginalAttackRange;
public float EnemyOriginalWaves;
#endregion

    MoveScript move;
    Health health;
    LaserDamage laserDamage;
    DamageGun gunDamage;

    enemylookingplayer enemyLook;
    entity enemyEntity;
    GeneratingEnemies genEnemies;

    static readonly Color32 upColor = new Color32(0, 255, 0, 255);
    static readonly Color32 downColor = new Color32(255, 0, 0, 255);
    static readonly Color32 sameColor = new Color32(255, 255, 255, 255);

    void Awake()
    {
        if (Laser) laserDamage = Laser.GetComponent<LaserDamage>();
        if (Gun) gunDamage = Gun.GetComponent<DamageGun>();

        if (enemy)
        {
            enemyLook = enemy.GetComponent<enemylookingplayer>();
            enemyEntity = enemy.GetComponent<entity>();
        }

        if (Scripts) genEnemies = Scripts.GetComponent<GeneratingEnemies>();
    }

    void Update()
    {
        #region IF
        if (Fred && Fred.activeSelf)
        {
            Player = Fred;
            Weapon = Laser;
            originalWalk = 6;
            originalRun = 12;
            originalHealth = 200;
            originalDamage = 0.5f;
            originalStamina = 100;
            originalStaminaDrain = 40;
        }
        else if (Bob && Bob.activeSelf)
        {
            Player = Bob;
            Weapon = Gun;
            originalWalk = 8;
            originalRun = 20;
            originalHealth = 100;
            originalDamage = 15f;
            originalStamina = 120;
            originalStaminaDrain = 15;
        }
        else if (Mate && Mate.activeSelf)
        {
            Player = Mate;
            Weapon = null;
        }
        #endregion

        if (!Player) return;

        if (!move) move = Player.GetComponent<MoveScript>();
        if (!health) health = Player.GetComponent<Health>();

        #region PlayerStats
        SetStat(WalkCurrent, move.walkingSpeed, originalWalk);
        SetStat(RunCurrent, move.runningSpeed, originalRun);
        SetStat(HealthCurrent, health.maxPlayerHealth, originalHealth);
        SetStat(StaminaCurrent, move.MaxStamina, originalStamina);
        SetStat(StaminaDrainCurrent, move.ChargeRate, originalStaminaDrain);

        SetStat(EnemyWalkCurrent, enemyLook.speed, EnemyOriginalWalk);
        SetStat(EnemyDamageCurrent, enemyLook.damageAmount, EnemyOriginalDamage);
        SetStat(EnemyHealthCurrent, enemyEntity.StartingHealth, EnemyOriginalHealth);
        SetStat(EnemyAttackSpeedCurrent, enemyLook.attackInterval, EnemyOriginalAttackSpeed);
        SetStat(EnemyAttackRangeCurrent, enemyLook.detectionRadius, EnemyOriginalAttackRange);
        SetStat(WaveOfEnemiesCurrent, genEnemies.maxEnemyCount, EnemyOriginalWaves);

        float damage = 0f;
        if (Weapon == Laser && laserDamage) damage = laserDamage.Damage;
        else if (Weapon == Gun && gunDamage) damage = gunDamage.Damage;
        SetStat(DamageCurrent, damage, originalDamage);
        #endregion

        #region EnemyStats
        if (enemyLook)
        {
            EnemyWalkCurrent.text = enemyLook.speed.ToString();
            EnemyDamageCurrent.text = enemyLook.damageAmount.ToString();
            EnemyAttackSpeedCurrent.text = enemyLook.attackInterval.ToString();
            EnemyAttackRangeCurrent.text = enemyLook.detectionRadius.ToString();
        }
        if (enemyEntity) EnemyHealthCurrent.text = enemyEntity.StartingHealth.ToString();
        if (genEnemies) WaveOfEnemiesCurrent.text = genEnemies.maxEnemyCount.ToString();
        #endregion
    }

    void SetStat(TextMeshProUGUI label, float value, float original)
    {
        if (!label) return;

        label.text = value.ToString();

        if (value > original) label.color = upColor;
        else if (value < original) label.color = downColor;
        else label.color = sameColor;
    }
}