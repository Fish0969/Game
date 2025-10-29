using UnityEngine;

public class Enemy : MonoBehaviour
{

     private float countdown = 5f;
     private WaveSystem waveSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        waveSystem= GetComponentInParent<WaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            Destroy(gameObject);
            waveSystem.waves[waveSystem.currentWaveIndex].enemiesLeft--;
        }
    }
}
