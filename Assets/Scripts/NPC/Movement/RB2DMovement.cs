using UnityEngine;

public class RB2DMovement : MonoBehaviour, IMovement
{
    public Vector2 MovementPoint { get; set; }
    public bool OnPosition { get; set; }

    public IDirection Direction;

    Rigidbody2D rb2D;

    Vector2 direction;
    Vector2 distance;

    float sqrDistance;
    [SerializeField]
    float minDistanceToPoint = 0.5f;
    float minSqrDistanceToPoint;
    [SerializeField]
    float maxVelosity = 2;
    float maxSqrVelosity;
    [SerializeField]
    float stopForce = 8;
    [SerializeField]
    float forse = 2;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Direction = GetComponent<IDirection>(); 
    }

    void Start()
    {
        minSqrDistanceToPoint = minDistanceToPoint * minDistanceToPoint;
        maxSqrVelosity = maxVelosity * maxVelosity;
    }

    void Update()
    {
        distance = (Vector3)MovementPoint - transform.position;
        sqrDistance = distance.sqrMagnitude;

        if (sqrDistance < minSqrDistanceToPoint)
        {
            direction = Direction.Stop(stopForce);
            OnPosition = true;
        }
        else if (rb2D.velocity.sqrMagnitude < maxSqrVelosity || rb2D.velocity.normalized != direction.normalized)
        {
            direction = Direction.Gas(forse);
            OnPosition = false;
        }
        else
        {
            direction = Direction.SlowDown();
            OnPosition = false;
        }
    }

    void FixedUpdate()
    {
        ForceAtDirection(direction);
    }

    void ForceAtDirection(Vector2 direction) => rb2D.AddForce(direction, ForceMode2D.Force);
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(MovementPoint, minDistanceToPoint);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, direction);

        if (OnPosition)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector2.up * 2);
        }
    }
}