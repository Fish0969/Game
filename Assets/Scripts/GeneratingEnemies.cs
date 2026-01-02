using System.Collections;
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
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject player;
    public TMPro.TextMeshProUGUI buffingTxt;
    public TMPro.TextMeshProUGUI WinTxt;
    public float interval;
    


    void OnEnable()
    {

        Invoke("EnemyCoroutine", 2f);

    }
    void EnemyCoroutine()
    {
        StartCoroutine(Enemydrop());
    }
    void Update()
    {
        if (player.activeSelf)
        {
            //DisplayScores();
        }
        else 
        {
         scoreText.gameObject.SetActive(false);
        }
    }


    IEnumerator Enemydrop()
    {
        while (enemyCount < maxEnemyCount)
        {
            Xpos = Random.Range(-20, 13);
            Zpos = Random.Range(3, 42);
            Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity, spawnedEnemys);
            yield return new WaitForSeconds(interval);
            enemyCount += 1;
        }
        // if (enemyCount == 50)
        // {
        //     enemyCount = 0;
        //     buffingTxt.gameObject.SetActive(true);
        //     while (enemyCount < 50)
        //     {
        //     Xpos = Random.Range(-20, 7);
        //     Zpos = Random.Range(20, 40);
        //     Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity, spawnedEnemys);
        //     yield return new WaitForSeconds(1.6f);
        //     enemyCount += 1;
        //     enemy.GetComponent<enemylookingplayer>().speed = 5;
        //     enemy.GetComponent<enemylookingplayer>().damageAmount = 30;
        //     }
        //     if (enemyCount == 50)
        //     {
        //     enemyCount = 0;
        //     buffingTxt.gameObject.SetActive(true);
        //     buffingTxt.text = "Enemies now one shot you!";
        //     }
        //     while (enemyCount < 50)
        //     {
        //     Xpos = Random.Range(-24, 7);
        //     Zpos = Random.Range(24, 40);
        //     Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity, spawnedEnemys);
        //     yield return new WaitForSeconds(1.6f);
        //     enemyCount += 1;
        //     enemy.GetComponent<enemylookingplayer>().speed = 6;
        //     enemy.GetComponent<enemylookingplayer>().damageAmount = 300;
        //     }
        //     if (enemyCount == 50)
        //     {
        //     WinTxt.gameObject.SetActive(true);
        //     }
        }
    }
//     }
//     public void DisplayScores()
//     {
//         scoreText.text = "Enemies left:" + (50 - enemyCount);
//     }
// }

