using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    [SerializeField] private float h_speed = 3f;
    [SerializeField] private float h_rotationSpeed = 5f;

    private void Update()
    {
        if (player == null) return;

        Vector3 target = player.transform.position;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            h_speed * Time.deltaTime
        );

        Vector3 direction = target - transform.position;

        if (direction.magnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                h_rotationSpeed * Time.deltaTime
            );
        }
    }
}