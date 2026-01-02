using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;



public class LaserDamage : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    public Transform playercamera;
    

    public void OnLaserShoot()
    {

        
        Ray gunRay = new Ray(playercamera.position, playercamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out entity enemy))
            {
                enemy.Health -= Damage;

                

            }
        }
    }

}
