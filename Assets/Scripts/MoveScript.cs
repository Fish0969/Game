using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class MoveScript : MonoBehaviour
{
    public UnityEvent HealingAction;
    public Camera playerCamera;
    public float walkingSpeed = 6f;
    public float runningSpeed = 12f;
    private float CurrentWalkingSpeed;
    private float CurrentRunningSpeed;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float crouchHeight = 1;
    public float standingHeight = 2.0f;
    public float crouchSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public GameObject resetpov;
    public float CurrentStamina, MaxStamina, Runcost, ChargeRate;
    public UnityEngine.UI.Image StaminaBar;
    private bool canMove = true;
    private Coroutine recharge;
    public TextMeshProUGUI StaminaNumber;

    void Start()
    {
        CurrentWalkingSpeed = walkingSpeed;
        CurrentRunningSpeed = runningSpeed;
        characterController = GetComponent<CharacterController>();


    }


    void Update()
    {

        StaminaNumber.text = CurrentStamina.ToString("F0");
        if (CurrentStamina <= 0)
        {
            CurrentStamina = 0;
        }
        Vector3 forward = transform.transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            CurrentStamina -= Runcost * Time.deltaTime;
            StaminaBar.fillAmount = CurrentStamina / MaxStamina;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());

            if (CurrentStamina <= 0)
            {
                isRunning = false;

            }
        }

        float curSpeedX = canMove ? (isRunning ? CurrentRunningSpeed : CurrentWalkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? CurrentRunningSpeed : CurrentWalkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkingSpeed = crouchSpeed;
            runningSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = standingHeight;
            CurrentWalkingSpeed = walkingSpeed;
            CurrentRunningSpeed = runningSpeed;
        }


        characterController.Move(moveDirection * Time.deltaTime);
        if (!resetpov.activeSelf)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        //Check this out later
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (CurrentStamina < MaxStamina)
        {

            CurrentStamina += ChargeRate / 10f;
            if (CurrentStamina > MaxStamina) CurrentStamina = MaxStamina;
            StaminaBar.fillAmount = CurrentStamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }
}
