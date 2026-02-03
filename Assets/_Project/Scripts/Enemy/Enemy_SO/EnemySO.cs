using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    public float MoveSpeed = 10f;
    public int health = 3;
    public GameObject bulletPrefab;

    public int spawnChance = 50;
    public float moveDistance = 5f;

    public float shootInterval = 2f;
}
