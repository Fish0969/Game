using UnityEngine;

public class enemylookingplayer : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public Rigidbody rb;
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public float damageAmount = 10f;
    private Vector3 movement;
    float attackTimer;
    public float attackInterval = 0.5f;

    private void Update()
    {
      if (attackTimer > 0)
        attackTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                Health playerHealth = hit.GetComponent<Health>();
                if (playerHealth != null && attackTimer <= 0)
                {
                    playerHealth.Damage(damageAmount);
                    attackTimer = attackInterval;
                }
            }
        }

        Vector3 target = player.position;
        target.y = transform.position.y;
        transform.LookAt(target);
        movement = transform.forward * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}