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

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movementInput = _inputSystem.Player.Move.ReadValue<Vector2>();
        _playerRb.linearVelocity = new Vector2(_movementInput.x * moveSpeed, _movementInput.y * moveSpeed);
    }
}
