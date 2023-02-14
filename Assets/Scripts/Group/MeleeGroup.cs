using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGroup : MonoBehaviour
{
    public Vector2 GroupPosition { get; set; }

    IGroup Group;
    IMeleeGroupMovement MeleeGroupMovement;
    IRouteBuilder RouteBuilder;

    void Awake()
    {
        Group = GetComponent<IGroup>();
        MeleeGroupMovement = GetComponent<IMeleeGroupMovement>();
        RouteBuilder = GetComponent<IRouteBuilder>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            MeleeGroupMovement.SetMeleePosition(2, Group.Enemies);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GroupPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RouteBuilder.BuildRoute(GroupPosition);
        }
    }
}