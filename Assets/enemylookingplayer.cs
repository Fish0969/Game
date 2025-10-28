using Unity.VisualScripting;
using UnityEngine;

public class enemylookingplayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        this.gameObject.transform.LookAt(player);
    }
}
