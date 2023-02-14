using UnityEngine;

public class TwoBySixMatrix : MonoBehaviour, IPlacementMatrix
{
    public bool[][] Points { get => points; private set => points = value; }

    public bool[][] points =
    {
       new bool[] { true, true, true, true, true, true },
       new bool[] { true, true, true, true, true, true }
    };
}