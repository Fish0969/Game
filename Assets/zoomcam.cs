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
    private float Xrotation;
    
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
        
        if (Input.GetButtonDown("Zoom"))
        {
            isZoomed = !isZoomed; 
        }

        if (isZoomed && targetCapsule != null)
        {

            Vector3 targetPosition = targetCapsule.position - targetCapsule.forward * 0f + Vector3.up * 0f;

            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 500;
            Xrotation -= mouseY;
            Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
            transform.rotation = Quaternion.Euler(Xrotation, transform.rotation.eulerAngles.y, 0);

            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed * Time.deltaTime);
            
            Quaternion targetRotation = Quaternion.LookRotation(targetCapsule.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, zoomSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, zoomSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, zoomSpeed * Time.deltaTime);
        }
        
    }
}
