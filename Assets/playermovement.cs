using UnityEngine;
public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintMultiplier = 1.5f;
    [SerializeField] private float mouseSensitivity = 5f;
    
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float groundCheckDistance = 0.3f;
    [SerializeField] private LayerMask groundMask = -1;

    private Vector3 moveDirection;
    private float rotationY;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isSprinting;
    public Transform Camera;
    public GameObject resetpov;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        rb.freezeRotation = true;
        rb.mass = 1.5f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        CheckGrounded();
        HandleInput();
        HandleRotation();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckGrounded()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.1f;
        
        RaycastHit hit;
        isGrounded = Physics.Raycast(rayStart, Vector3.down, out hit, groundCheckDistance + 0.1f, groundMask);


    }

    private void HandleInput()
    {
        
        
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

            isSprinting = Input.GetKey(KeyCode.LeftShift);

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Vector3 vel = rb.linearVelocity;
                vel.y = 0f;
                rb.linearVelocity = vel;

                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

                Debug.Log(jumpForce + "funny beans🤣");
            } 
    }

    private void ApplyMovement()
    {
        float currentSpeed = speed;
        if (isSprinting) currentSpeed *= sprintMultiplier;

        Vector3 moveVelocity = transform.TransformDirection(moveDirection) * currentSpeed;
        
        moveVelocity.y = rb.linearVelocity.y;
        
        rb.linearVelocity = moveVelocity;
    }

    private void HandleRotation()
    {
        if (!resetpov.activeSelf)
        {
            float mouseX = Input.GetAxis("Mouse X");
            rotationY += mouseX * mouseSensitivity;

            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

            float mouseY = Input.GetAxis("Mouse Y");
            float Xrotation = Camera.localEulerAngles.x - mouseY * mouseSensitivity;
            Xrotation = (Xrotation > 180) ? Xrotation - 360 : Xrotation;
            Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
            Camera.localEulerAngles = new Vector3(Xrotation, 0f, 0f);
        }
        
    }


}
