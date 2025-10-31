using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UIElements;



public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public bool Automatic;
    private float CurrentCooldown;
    [SerializeField] public GameObject bulletprefab;
    [SerializeField] public Transform targetp;
    public Transform PlayerCamera;
    public float bulletspeed = 10f;


    void Start()
    {

        CurrentCooldown = FireCooldown;

    }

    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    //var bullet = Instantiate(bulletprefab, targetp.position, targetp.rotation);
                    //bullet.GetComponent<Rigidbody>().linearVelocity = targetp.forward * bulletspeed;
                    ///////////////////////////////////////////////////////////////////////////////////
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    
                    //var bullet = Instantiate(bulletprefab, targetp.position, targetp.rotation);
                    //bullet.GetComponent<Rigidbody>().linearVelocity = targetp.forward * bulletspeed;
                    /////////////////////////////////////////////////////////////////////////////
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }

}