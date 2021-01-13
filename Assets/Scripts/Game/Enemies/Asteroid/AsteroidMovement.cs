using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] [Min(0)] private float moveSpeed;

    private Vector2 moveDirection;

    private void Awake()
    {
        moveDirection = GetRandomInitialMoveDirection();
    }

    private void Update()
    {
        ApplyMove();
    }

    private void ApplyMove()
    {
        transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private Vector2 GetRandomInitialMoveDirection()
    {
        return Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward) * Vector2.right;
    }
}
