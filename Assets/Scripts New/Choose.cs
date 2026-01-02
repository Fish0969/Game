using UnityEngine;

public class Choose : MonoBehaviour
{
    public GameObject enemy;
    public Transform Fred;
    public Transform Bob;
    public Transform Mate;
    void Start()
    {
        
    }

    public void BeingBob()
    {
        enemy.GetComponent<enemylookingplayer>().player = Bob;
    }
    public void BeingMate()
    {
        enemy.GetComponent<enemylookingplayer>().player = Mate;
    }
}
