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
            Xpos = Random.Range(-20, 7);
            Zpos = Random.Range(20, 40);
            Instantiate(enemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            enemyCount+=1;

        
        }
    }

}

