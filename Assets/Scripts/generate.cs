using System.Collections;
using UnityEngine;
using TMPro;

public class generate : MonoBehaviour
{
    public GameObject enemy;
    public int X;
    public int Y;

    public int enemynumber;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject player;


    void Start()
    {
        StartCoroutine(Spawner());

    }
    void Update()
    {
        if (player.activeSelf)
        {
            DisplayScores();
        }
    }

    IEnumerator Spawner()
    {
        X = Random.Range(28, 42);
        Y = Random.Range(-28, -10);

        if (enemynumber < 1000)
        {
            Instantiate(enemy, new Vector3(X, 0, Y), Quaternion.identity);
            yield return new WaitForSeconds(1);
            enemynumber += 1;
        }
    }
    public void DisplayScores()
    {
        scoreText.text = "Score:" + enemynumber * 100;

    }
}
