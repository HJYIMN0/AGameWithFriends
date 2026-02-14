using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController_FallingGame : MonoBehaviour
{
    [SerializeField] private int hP = 3;
    [SerializeField] private int maxHP = 3;
    [SerializeField] private bool isInvincible = false;

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        hP -= damage;
        if (hP <= 0)
        {
            hP = 0;
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
