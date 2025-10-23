using UnityEngine;
using UnityEngine.Splines;

public class zoomcam : MonoBehaviour
{
    [SerializeField]
    private Transform targetCapsule;
    
    [SerializeField]
    private float zoomSpeed = 5f;
    
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isZoomed = false;
    
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        originalPosition = targetCapsule.position - targetCapsule.forward * 5f + Vector3.up * 2f;
        originalRotation = Quaternion.LookRotation(targetCapsule.position - originalPosition);
        
        if (Input.GetButtonDown("Jump"))
        {
            isZoomed = !isZoomed; 
        }

        if (isZoomed && targetCapsule != null)
        {
           
            Vector3 targetPosition = targetCapsule.position - targetCapsule.forward * -3f + Vector3.up * -.5f;
            

            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed * Time.deltaTime);
            
            Quaternion targetRotation = Quaternion.LookRotation(targetCapsule.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, zoomSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, zoomSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, zoomSpeed * Time.deltaTime);
        }

    }
}
