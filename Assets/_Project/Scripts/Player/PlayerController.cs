using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private Vector2 _movementInput;
    private InputSystem_Actions _inputSystem;

    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _inputSystem = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputSystem.Player.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Player.Disable();
    }

    private void Update()
    {
        _movementInput = _inputSystem.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (IsMoving())
        {
            Move();
        }
        else
        {
            _playerRb.linearVelocity = new Vector2(0, 0);
        }
    }

    public bool IsMoving() => _movementInput.x != 0;

    private void Move()
    {        
        _playerRb.linearVelocity = new Vector2(_movementInput.x * moveSpeed, 0);
    }
}
