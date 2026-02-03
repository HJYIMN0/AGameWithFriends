using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp = 3;

    public int HP => hp;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        hp = Mathf.Max(hp, 0);
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Game Over logic can be added here
    }
}
