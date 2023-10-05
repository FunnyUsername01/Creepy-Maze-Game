using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Movement and player
    public Rigidbody playerBody;
    public float moveSpeed = 0.5f;
    Vector3 moveDirection = Vector3.zero;

    //Input reference
    public InputAction playerControls;
    public InputAction interactButton;
    public InputAction shootButton;


    //Requirements for new input system
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        playerBody.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * 0, moveDirection.z * moveSpeed);
    }
}
