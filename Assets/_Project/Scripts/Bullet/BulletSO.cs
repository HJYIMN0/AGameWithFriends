using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletSO", order = 1)]
public class BulletSO : ScriptableObject
{
    public float bulletLife = 2f;
    public float bulletSpeed = 10f;
    public int bulletDamage = 1;

    public GameObject bulletPreFab;

    public BulletDirection bulletDirection;
}
public enum BulletDirection
{
    Up,
    Down
}

