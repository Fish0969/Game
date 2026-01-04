using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interacts : MonoBehaviour
{
    public Transform InteractorSource;
    public GameObject FredCam;
    public GameObject BobCam;
    public float InteractorRange;
    void Start()
    {

        

        if (FredCam.activeSelf)
        {
            InteractorSource = FredCam.GetComponent<Transform>();
            Debug.Log("fred");
        };

        if (BobCam.activeSelf)
        {
            InteractorSource = BobCam.GetComponent<Transform>();
            Debug.Log("Bob");
        }
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactobj))
                {
                    interactobj.Interact();
                }

            }
        }
    }
}