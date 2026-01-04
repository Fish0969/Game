using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ParentCounter : MonoBehaviour
{
    public int destroyedCount;
    public Vector3 lastDestroyedPosition;
    public TextMeshProUGUI Killed;
    public int lucky1;
    public int lucky2;
    public GameObject Hearth;
    public int killedEnemies;
    public GameObject spawnPrefab; // assign in Inspector

    public void ChildDestroyed(Vector3 position)
    {
        killedEnemies++;
        Killed.text = ("Enemies killed: " + killedEnemies);
        lucky1 = Random.Range(1, 8);
        lucky2 = Random.Range(1, 8);

        if (lucky1 == lucky2)
        {

        Instantiate(spawnPrefab, position, Quaternion.identity); 
        }}
}
