using TMPro;
using UnityEngine;

public class ParentCounter : MonoBehaviour
{
    public int destroyedCount;
    public Vector3 lastDestroyedPosition;
    public TextMeshProUGUI Killed;

    public void ChildDestroyed(Vector3 position)
    {
        destroyedCount++;
        lastDestroyedPosition = position;

        Debug.Log(destroyedCount + " " +  position);
        Killed.text = destroyedCount.ToString();
    }
}
