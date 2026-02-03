using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private BulletSO bulletData;
    public BulletSO BulletData => bulletData;
    public void SetBulletData (BulletSO bulletData) => this.bulletData = bulletData;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, BulletData.bulletLife);

        Vector2 bulletDirection = Vector2.zero;
        switch (BulletData.bulletDirection)
        {
            case BulletDirection.Up:
                bulletDirection = transform.up;
                break;
            case BulletDirection.Down:
                bulletDirection = - transform.up;
                break;
        }

        rb.linearVelocity = bulletDirection * BulletData.bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Accediamo al GameObject coinvolto nella collisione e tentiamo di ottenere l'interfaccia
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(BulletData.bulletDamage);
            Debug.Log("Found!");
        }

        // Distruggiamo il proiettile indipendentemente dal fatto che abbia colpito un oggetto danneggiabile o un muro
        Destroy(gameObject);
    }
}


