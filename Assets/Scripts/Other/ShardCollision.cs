using UnityEngine;

public class ShardCollision : MonoBehaviour
{
    // Detect collision with a player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Invoke OnCoin signal
            GameSignals.OnCoinPicked?.Invoke();
            
            // Then destroys the coin
            Destroy(gameObject);
        }
    }
}
