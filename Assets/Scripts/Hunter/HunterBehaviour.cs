using UnityEngine;

public class HunterBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameSignals.OnGameOver?.Invoke();
        }
    }
}
