using Unity.VisualScripting;
using UnityEngine;

public class enemylookingplayer : MonoBehaviour
{
    public Transform player;
    private Vector3 movement;
    public float speed = 1f;
    public Rigidbody rb;

    void Update()
    {
        Vector3 target = player.position;
        target.y = transform.position.y;
        this.gameObject.transform.LookAt(target);

        movement = transform.forward * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }


}
