using UnityEngine;

public interface IMovement
{
    public Vector2 MovementPoint { get; set; }
    public bool OnPosition { get; set; }
}
