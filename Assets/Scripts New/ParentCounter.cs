using TMPro;
using UnityEngine;

public class ParentCounter : MonoBehaviour
{
    public TextMeshProUGUI EnemiesKilled;
    public int destroyedCount;

    public void ChildDestroyed()
    {
        destroyedCount++;
        //Debug.Log("Enemies killed: " + destroyedCount);
        EnemiesKilled.text = ("Enemies killed: " + destroyedCount.ToString());
    }
}
