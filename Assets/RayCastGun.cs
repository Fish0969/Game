using System.Collections;
using UnityEngine;

public class RayCastGun : MonoBehaviour
{
    public Camera PlayerCamera;
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
            laserLine.SetPosition(0, LaserOrigin.position);
            Vector3 rayOrigin = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, PlayerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (PlayerCamera.transform.forward * gunRange));
            }
        }
    }



}

