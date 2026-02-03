using UnityEngine;

public class EnemyLogic : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemySO enemyData;

    private Rigidbody2D _enemyRigidBody;
    public EnemySO EnemyData => enemyData;

    private Vector2 _destination;

    private void OnEnable()
    {
        _enemyRigidBody = GetComponent<Rigidbody2D>();
        _destination = new Vector2(transform.position.x, transform.position.y - enemyData.moveDistance);
    }

    private void FixedUpdate()
    {
        _enemyRigidBody.MovePosition(Vector2.MoveTowards(transform.position, _destination,
                                                        enemyData.MoveSpeed * Time.fixedDeltaTime));
    }

    public void TakeDamage(int damage)
    {
        enemyData.health -= damage;
        enemyData.health = Mathf.Max(enemyData.health, 0);
        if (enemyData.health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        //Score increment logic can be added here
    }
}
