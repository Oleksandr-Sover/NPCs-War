using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RouteBuilder : MonoBehaviour, IRouteBuilder
{
    IGroup Group;
    IGroupMovement GroupMovement;

    List<Vector2> waypoints = new List<Vector2>();

    Vector2 groupPosition;
    Vector2 distance;
    Vector2 position;
    Vector2 stepVector;

    [SerializeField]
    float stepLength;
    float length;

    [SerializeField]
    int amountOfPoints;

    bool onPositions;
    bool newPosition;

    void Awake()
    {
        Group = GetComponent<IGroup>();
        GroupMovement = GetComponent<IGroupMovement>();
    }

    void Update()
    {
        if (waypoints.Count > 0 && AreNPCsOnPosition())
            SetPosition();

        if (newPosition)
        {
            newPosition = false;
            SetPosition();
        }
    }

    void SetPosition()
    {
        GroupMovement.SetPositions(waypoints.Last());
        waypoints.RemoveAt(waypoints.Count - 1);
    }

    public void BuildRoute(Vector2 targetPosition)
    {
        newPosition = true;
        waypoints.Clear();

        groupPosition = Group.NPCsGroup[0].transform.position;
        distance = targetPosition - groupPosition;
        length = distance.magnitude;
        amountOfPoints = (int)(length / stepLength);
        stepVector = distance / amountOfPoints;

        position = targetPosition;
        waypoints.Add(position);

        for (int i = 0; i < amountOfPoints; i++)
        {
            position -= stepVector;
            waypoints.Add(position);
        }
    }

    bool AreNPCsOnPosition()
    {
        onPositions = true;

        foreach (var npc in Group.NPCsGroup)
        {
            if (!npc.Movement.OnPosition)
            {
                onPositions = false;
                break;
            }
        }
        return onPositions;
    }
}