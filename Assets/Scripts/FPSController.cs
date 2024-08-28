using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public float gravity;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    // Speed boost variables
    public float boostSpeed = 10f;
    public float boostDuration = 5f;
    private bool isBoostActive = false;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Handles Movement 
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Calculate current speeds with boost applied
        float currentWalkSpeed = isBoostActive ? walkSpeed + boostSpeed : walkSpeed;
        float currentRunSpeed = isBoostActive ? runSpeed + boostSpeed : runSpeed;

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? currentRunSpeed : currentWalkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? currentRunSpeed : currentWalkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        // Check if the speed boost should be activated
        //if (Input.GetKeyDown(KeyCode.B) && !isBoostActive)
       // {
         //   StartCoroutine(SpeedBoost());
     //   }
    }

   /* private IEnumerator SpeedBoost()
    {
        isBoostActive = true;
        yield return new WaitForSeconds(boostDuration);
        isBoostActive = false;
    }*/
}
