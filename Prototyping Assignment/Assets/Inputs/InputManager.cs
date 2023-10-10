using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerConstrols playerConstrols;

    private static InputManager _instance;

    public static InputManager Instance
    {
        get  { return _instance; }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        playerConstrols = new PlayerConstrols();
        Cursor.visible = false;
    }

    //Requirements for new input system
    private void OnEnable()
    {
        playerConstrols.Enable();
    }
    private void OnDisable()
    {
        playerConstrols.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerConstrols.Player.Movement.ReadValue<Vector2 > ();
    }

    public Vector2 GetMouseDelta()
    {
        return playerConstrols.Player.Look.ReadValue<Vector2>();
    }
}
