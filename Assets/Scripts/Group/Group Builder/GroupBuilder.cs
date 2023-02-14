using UnityEngine;

public class GroupBuilder : MonoBehaviour, IGroupBuilder
{
    IPlacementMatrix PlacementMatrix;

    Vector2 position;

    [SerializeField]
    float distanceBetweenNPC;

    public delegate void InstallNPC(Vector2 position);

    void Awake()
    {
        PlacementMatrix = GetComponent<IPlacementMatrix>();
    }

    public void BuildGroup(Vector2 groupPosition, InstallNPC installNPC)
    {
        position = groupPosition;
        position.x -= distanceBetweenNPC;
        position.y -= distanceBetweenNPC;

        foreach (var line in PlacementMatrix.Points)
        {
            position.y += distanceBetweenNPC;
            position.x = groupPosition.x - distanceBetweenNPC;

            foreach (var point in line)
            {
                position.x += distanceBetweenNPC;

                if (point)
                    installNPC(position);
            }
        }
    }
}