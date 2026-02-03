using UnityEngine;

public class EnemyShootingLogic : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    private EnemyLogic _enemyLogic;
    private EnemySO _enemyData;

    private float _shootTimer;
    private void OnEnable()
    {
        _enemyLogic = GetComponent<EnemyLogic>();
        _enemyData = _enemyLogic.EnemyData;
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _enemyData.shootInterval)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        Instantiate(_enemyData.bulletPrefab, shootPoint.transform.position, Quaternion.identity);
    }
}
