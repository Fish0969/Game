using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviour
{
    public GameObject enemy;
    int Xpos;
    int Zpos;
    public int enemyCount;
    public int maxEnemyCount;
    public Transform spawnedEnemys;
    public TMPro.TextMeshProUGUI waves;
    public GameObject player;
    public int WavesCount;
    public float interval;
    public Transform Enemies;
    public int enemiesKilled;
    public float Timerer;

    public GameObject BuffButtons;


    public void WavesCounter()
    {
        WavesCount += 1;
        enemyCount = 0;
        StartCoroutine(Enemydrop());
        Debug.Log("Wave " + (WavesCount - 1) + " cleared");
        waves.text = ("Wave " + WavesCount);
        if (enemyCount == 0)
        {
            maxEnemyCount = 5 * WavesCount;
            interval = interval / WavesCount;
        }
    }


    void OnEnable()
    {
        WavesCount = 1;
        Invoke("EnemyCoroutine", 2f);

    }
    void EnemyCoroutine()
    {
        StartCoroutine(Enemydrop());
    }
    void Update()
    {
        if (Enemies.childCount <= 0)
        {

            if (enemyCount == maxEnemyCount)
            {
                BuffButtons.SetActive(true);

                if (!BuffButtons.activeSelf)
                {
                    {
                        waves.text = (Timerer + " seconds left till next round");
                        Invoke("WavesCounter", Timerer);

                    }
                }
            }
        }
    }



    IEnumerator Enemydrop()
    {
        while (enemyCount < maxEnemyCount)
        {

            Debug.Log("Wave " + (WavesCount) + " started");
            Xpos = UnityEngine.Random.Range(-20, 13);
            Zpos = UnityEngine.Random.Range(3, 42);
            Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity, spawnedEnemys);
            yield return new WaitForSeconds(interval);
            enemyCount += 1;
        }
    }
}


