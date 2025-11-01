using System.Collections;
using UnityEngine;

public class generate : MonoBehaviour
{
    public GameObject enemy;
    public int X;
    public int Y;

    public int enemynumber;

    void Start()
    {
        StartCoroutine(Spawner());

    }

    IEnumerator Spawner()
    {
        X = Random.Range(28, 42);
        Y = Random.Range(-28, -10);

        if (enemynumber < 1)
        {
            Instantiate(enemy, new Vector3(X, 0, Y), Quaternion.identity);
            yield return new WaitForSeconds(1);
            //enemynumber += 1;
        }
    }
}
