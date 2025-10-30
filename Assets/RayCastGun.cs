using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RayCastGun : MonoBehaviour
{
    public Camera PlayerCamera;
    public UnityEvent OnLaserShoot;
    public float FireCooldown = 1f;
    private float CurrentCooldown;
    public Transform LaserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;

    LineRenderer laserLine;
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            laserLine.enabled = true;
            laserLine.SetPosition(0, LaserOrigin.position);
            Vector3 rayOrigin = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, PlayerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                if (CurrentCooldown <= 0)
                {
                    OnLaserShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (PlayerCamera.transform.forward * gunRange));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            laserLine.enabled = false;
        }
    }
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    public float Damage;
    public Transform playerCamera;

    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gunRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out entity enemy))
            {
                enemy.Health -= Damage;
            }
        }
    }
}


