using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -5);

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!target) return;

        yaw += Input.GetAxis("Mouse X")*5;
        pitch -= Input.GetAxis("Mouse Y")*5;
        pitch = Mathf.Clamp(pitch, -35f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        target.Rotate(Vector3.up * Input.GetAxis("Mouse X")*5);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime*5);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}