using System.Collections;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviour
{
    public GameObject enemy;
    public int Xpos;
    public int Zpos;
    public int enemyCount;
    public Transform spawnedEnemys;
    

    void OnEnable()
    {
        
        StartCoroutine(Enemydrop());

    }


    IEnumerator Enemydrop()
    {
        while (enemyCount < 1000)
        {
            Xpos = Random.Range(-20, 7);
            Zpos = Random.Range(20, 40);
            Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity, spawnedEnemys);
            yield return new WaitForSeconds(1.6f);
            enemyCount += 1;

        
        }
    }

}

