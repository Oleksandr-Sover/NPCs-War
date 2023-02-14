using UnityEngine;

public class GroupMovement : MonoBehaviour, IGroupMovement
{
    IGroup Group;
    IGroupBuilder GroupBuilder;

    void Awake()
    {
        GroupBuilder = GetComponent<IGroupBuilder>();
        Group = GetComponent<IGroup>();
    }

    public void SetPositions(Vector2 groupPosition)
    {
        DropOnPositions();
        GroupBuilder.BuildGroup(groupPosition, InstallNPC);
    }

    public void DropOnPositions()
    {
        foreach (var npc in Group.NPCsGroup)
            npc.Movement.OnPosition = true;
    }

    void InstallNPC(Vector2 position)
    {
        foreach (var npc in Group.NPCsGroup)
        {
            if (npc.Movement.OnPosition)
            {
                npc.Movement.MovementPoint = position;
                npc.Movement.OnPosition = false;
                break;
            }
        }
    }
}