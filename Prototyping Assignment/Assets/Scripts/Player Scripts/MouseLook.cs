using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse : MonoBehaviour
{
    private InputMaster controls;
    private float mouseSensitivity = 100f;
    private Vector2 mouseLook;
    private float xRotation = 0f;
    public Transform playerBody;

    private void Awake()
    {
        playerBody = transform.parent;
        controls = new InputMaster();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look() 
    {
        //Access controls in inputmaster action
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        //Capture mouse values
        float mouseX  = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        //Limit camera rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //allawing local rotation + allow rotation for x plane
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
