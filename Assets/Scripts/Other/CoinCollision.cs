using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameSignals.OnCoin?.Invoke();
        }
    }
}
