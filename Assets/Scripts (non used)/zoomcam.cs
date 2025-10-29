using UnityEngine;
using UnityEngine.Splines;

public class zoomcam : MonoBehaviour
{
    [SerializeField]
    private Transform targetCapsule;
    
    [SerializeField]
    private float zoomSpeed = 5f;

    [SerializeField]
    private float minWallClearance = 0.5f;
    


    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isZoomed = false;
    private float Xrotation;
    public GameObject crosshair;

    private const float DefaultDistance = 5f;
    private const float DefaultHeight = 2f;
    private const float ZoomDistance = 0f;
    
    private const float ZoomHeight = 0.4f; 
    
    void Start()
    {
        if (targetCapsule != null)
        {
            originalPosition = targetCapsule.position - targetCapsule.forward * DefaultDistance + Vector3.up * DefaultHeight;
            originalRotation = Quaternion.LookRotation(targetCapsule.position - originalPosition);
        }
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        originalPosition = targetCapsule.position - targetCapsule.forward * DefaultDistance + Vector3.up * DefaultHeight;
        originalRotation = Quaternion.LookRotation(targetCapsule.position - originalPosition);

        if (Input.GetButtonDown("Zoom"))
        {
            isZoomed = !isZoomed;
            crosshair.SetActive(isZoomed);
        }


        Vector3 targetPosition;
        float currentTargetDistance;
        float currentTargetHeight;

        if (isZoomed && targetCapsule != null)
        {
            currentTargetDistance = ZoomDistance;
            currentTargetHeight = ZoomHeight;

            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 500;
            Xrotation -= mouseY;
            Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(Xrotation, transform.rotation.eulerAngles.y, 0);
            targetPosition = targetCapsule.position - targetCapsule.forward * currentTargetDistance + Vector3.up * currentTargetHeight;
        }
        else
        {
            currentTargetDistance = DefaultDistance;
            currentTargetHeight = DefaultHeight;
            
            targetPosition = originalPosition;
        }


        Vector3 pivotPoint = targetCapsule.position + Vector3.up * currentTargetHeight;
        
        Vector3 rayDirection = targetPosition - pivotPoint;
        float rayLength = rayDirection.magnitude;
        rayDirection.Normalize();

        Vector3 finalPosition = targetPosition;
        RaycastHit hit;

        if (Physics.Raycast(pivotPoint, rayDirection, out hit, rayLength))
        {
            float safeDistance = hit.distance - minWallClearance;
            
            safeDistance = Mathf.Max(0f, safeDistance);
            
            finalPosition = pivotPoint + rayDirection * safeDistance;
        }

        transform.position = Vector3.Lerp(transform.position, finalPosition, zoomSpeed * Time.deltaTime);

        if (isZoomed)
        {
            Quaternion playerRotation = Quaternion.Euler(Xrotation, targetCapsule.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, zoomSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, zoomSpeed * Time.deltaTime);
        }
    }
}