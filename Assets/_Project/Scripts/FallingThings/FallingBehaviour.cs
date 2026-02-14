using UnityEngine;

public class FallingBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private SO_FallingItem fallingItem;

    private void OnEnable()
    {
        if (fallingItem == null)
        {
            Debug.LogError("FallingBehaviour requires a SO_FallingItem component.");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallingItem.fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Falling object collided with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Player"))
        {
            Interact(collision.gameObject);
        }

    }

    public void Interact(GameObject player)
    {
        switch (fallingItem.isGoodItem)
        {
            case true:
                Debug.Log("Yet to implement score system, but this is where the player would gain points.");
                break;
            case false:
                player.GetComponent<PlayerLifeController_FallingGame>()?.TakeDamage(fallingItem.value);
                break;
        }
        Destroy(gameObject);
    }
}
