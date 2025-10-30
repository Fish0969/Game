using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RayCastGun : MonoBehaviour
{
    //public UnityEvent OnLaserShoot;
    //private float CurrentCooldown;
    //public float FireCooldown;
    public Camera PlayerCamera;
    public Transform LaserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;

    LineRenderer laserLine;
    
        void Start()
    {
        //CurrentCooldown = FireCooldown;
    }
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();

    }

    void Update()
    {
        laserLine.enabled = false;
        if (Input.GetMouseButton(0))
        {
            laserLine.enabled = true;
            laserLine.SetPosition(0, LaserOrigin.position);
            Vector3 rayOrigin = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, PlayerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                //OnLaserShoot?.Invoke();
                //CurrentCooldown = FireCooldown;

            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (PlayerCamera.transform.forward * gunRange));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            laserLine.enabled = false;
        }        //CurrentCooldown -= Time.deltaTime;

    }
    
}

