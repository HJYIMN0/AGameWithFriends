using UnityEngine;

[CreateAssetMenu(fileName = "SO_FallingItem", menuName = "ScriptableObjects/FallingItem", order = 1)]
public class SO_FallingItem : ScriptableObject
{
    public bool isGoodItem;
    public float fallSpeed = 1f;
    public int value;
}
