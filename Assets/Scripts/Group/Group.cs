using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour, IGroup
{
    public List<NPC> NPCsGroup { get => NPCs; set => NPCs = value; }

    List<NPC> NPCs = new List<NPC>();

    public List<GameObject> Enemies { get => enemies; set => enemies = value; }

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    Vector2 startGroupPosition;

    IGroupCreator GroupCreator;

    void Awake()
    {
        GroupCreator = GetComponent<IGroupCreator>();
    }

    void Start()
    {
        GroupCreator.CreateGroup(startGroupPosition);
    }
}