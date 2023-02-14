using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirection
{
    public Vector2 Gas(float force);
    public Vector2 SlowDown();
    public Vector2 Stop(float force);
}