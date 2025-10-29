using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public Gun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, GunContainer, MainCamera;
    public float pickupRange;
    public float dropForwardforce, dropUpwardforce;
    public bool equipped;
    public bool slotfull;

    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
                if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotfull = true;
        }
    }
    
    
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !slotfull) PickUp();
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

    }
    private void PickUp()
    {
        equipped = true;
        slotfull = true;

        transform.SetParent(GunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;
        gunScript.enabled = true;

    }
    private void Drop()
    {
        equipped = false;
        slotfull = false;

        transform.SetParent(null);


        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.linearVelocity = player.GetComponent<Rigidbody>().linearVelocity;
        rb.AddForce(MainCamera.forward * dropForwardforce, ForceMode.Impulse);
        rb.AddForce(MainCamera.up * dropUpwardforce, ForceMode.Impulse);
        float random = UnityEngine.Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
        
        gunScript.enabled = false;
    }


}
