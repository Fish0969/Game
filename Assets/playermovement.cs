using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float MoveSpeed = 10;
    [SerializeField] float Jump = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal") * MoveSpeed;
        float verInput = Input.GetAxis("Vertical") * MoveSpeed;

        rb.linearVelocity = new Vector3(horInput, rb.linearVelocity.y, verInput);
        if (Input.GetButtonDown("Jump")  && Mathf.Approximately(rb.linearVelocity.y,0)) rb.linearVelocity = new Vector3(rb.linearVelocity.x, Jump, rb.linearVelocity.z);

    }
}
