using UnityEngine;

public class RB2DDirection : MonoBehaviour, IDirection
{
    IMovement Movement;

    Rigidbody2D rb2D;

    Vector2 distance;

    float sqrDistance;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Movement = GetComponent<IMovement>();
    }

    public Vector2 Gas(float force)
    {
        distance = (Vector3)Movement.MovementPoint - transform.position;
        distance -= rb2D.velocity * 1.5f;
        return distance.normalized * force;
    }

    public Vector2 SlowDown()
    {
        distance = (Vector3)Movement.MovementPoint - transform.position;
        sqrDistance = distance.sqrMagnitude;
        return -rb2D.velocity / sqrDistance;
    }

    public Vector2 Stop(float force)
    {
        return force * -rb2D.velocity;
    }
}