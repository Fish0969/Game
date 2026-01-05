using UnityEngine;

public class XP : MonoBehaviour
{
public float XPAmount;
public GameObject enemy;
private float enemyHP;
public int KillCount;
public GameObject Parent;


    void Start()
    {
       
    }
    void Update()
    {
        KillCount = Parent.GetComponent<ParentCounter>().destroyedCount;
        
    }
}
