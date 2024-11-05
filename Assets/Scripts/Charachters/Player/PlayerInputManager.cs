using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;

    [SerializeField] private Vector2 movementInput;

    private InputSystem_Actions inputActions;

    public Vector2 MovementInput => movementInput;
    public InputSystem_Actions InputActions => inputActions;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new InputSystem_Actions();

            inputActions.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();

            inputActions.Enable();
        }
    }
}
