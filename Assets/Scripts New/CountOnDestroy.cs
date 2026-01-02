using UnityEngine;

public class CountOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        if (!Application.isPlaying) return;

        transform.parent?
            .GetComponent<ParentCounter>()?
            .ChildDestroyed(transform.position);
    }
}
