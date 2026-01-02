using System.Threading;
using UnityEngine;

public class playerLookAtEnemySC2 : MonoBehaviour
{
    public Transform enemy;
    public float speed;
    private Vector3 movement;
    public Rigidbody rb;
    float Timer;
    public float X;
    public float Y;
    public float distance;
    


    void Update()
    {
        
        if (Timer > 0) Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 1;
            float random = Random.Range(0, 3);
            if (random == 0)
            {
                X = 1;
                Y = 0;
            }
            else if (random == 1)
            {
                X = -1;
                Y = 0;
            }
            else if (random == 2)
            {
                X = 0;
                Y = 1;
            }
            else if (random == 3)
            {
                X = 0;
                Y = -1;
            }
        }
        
        
        Vector3 target = enemy.position;
        target.y = transform.position.y;
        transform.LookAt(target);
        movement = transform.forward * -speed;
        rb.linearVelocity = new Vector3(movement.x*X, rb.linearVelocity.y, movement.z);
    }
}
