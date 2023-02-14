using UnityEngine;

public class NPC : MonoBehaviour
{
    public IAttack Attack;
    public IMovement Movement;
    public IProtection Protection;

    void Awake()
    {
        Attack = GetComponent<IAttack>();
        Movement = GetComponent<IMovement>();
        Protection = GetComponent<IProtection>();
    }
}