using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroup
{
    List<NPC> NPCsGroup { get; set; }
    List<GameObject> Enemies { get; set; }
}
