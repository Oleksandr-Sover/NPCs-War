using System.Collections.Generic;
using UnityEngine;

public class GroupCreator : MonoBehaviour, IGroupCreator
{
    IGroupBuilder GroupBuilder;
    IGroup Group;

    public GameObject npcPrefab;
    GameObject npcGO;

    NPC npc;

    void Awake()
    {
        GroupBuilder = GetComponent<IGroupBuilder>();
        Group = GetComponent<IGroup>();
    }

    public void CreateGroup(Vector2 groupPosition)
    {
        GroupBuilder.BuildGroup(groupPosition, InstantiateNPC);
    }

    void InstantiateNPC(Vector2 position)
    {
        npcGO = Instantiate(npcPrefab, (Vector3)position, Quaternion.identity);
        npc = npcGO.gameObject.GetComponent<NPC>();
        npc.Movement.MovementPoint = position;
        Group.NPCsGroup.Add(npc);
    }
}