using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float _shootCooldown = 0.5f;

    private PlayerController _playerController;
    private float _lastShootTime;


    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerController.IsMoving())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _lastShootTime += Time.deltaTime;

        if (_lastShootTime > _shootCooldown)
        { 
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            _lastShootTime = 0f;
        }
    }
}
