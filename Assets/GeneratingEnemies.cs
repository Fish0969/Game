using System.Collections;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviour
{
    public GameObject enemy;
    public int Xpos;
    public int Zpos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(Enemydrop());
    }

    IEnumerator Enemydrop()
    {
        while (enemyCount < 10)
        {
            Xpos = Random.Range(-20, 10);
            Zpos = Random.Range(3, 30);
            Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            enemyCount+=1;
        
        
        }
    }

}

