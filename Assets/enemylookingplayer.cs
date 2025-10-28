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

        this.gameObject.transform.LookAt(player);

        movement = transform.forward * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }


}
