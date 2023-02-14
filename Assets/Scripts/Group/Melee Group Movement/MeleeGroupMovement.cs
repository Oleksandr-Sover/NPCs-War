using System.Collections.Generic;
using UnityEngine;

public class MeleeGroupMovement : MonoBehaviour, IMeleeGroupMovement
{
    IGroup Group;

    int stepNum = 0;
    int enemyNum = 0;
    int enemiesNum;

    void Awake()
    {
        Group = GetComponent<IGroup>(); 
    }

    public void SetMeleePosition(int npcPerEnemy, List<GameObject> enemies)
    {
        stepNum = npcPerEnemy;
        enemiesNum = enemies.Count - 1;
        enemyNum = 0;

        foreach (var npc in Group.NPCsGroup)
        {
            npc.Movement.MovementPoint = enemies[enemyNum].transform.position;
            stepNum--;

            if (stepNum <= 0)
            {
                stepNum = npcPerEnemy;

                if (enemyNum < enemiesNum)
                    enemyNum++;
                else
                    enemyNum = 0;
            }
        }
    }
}