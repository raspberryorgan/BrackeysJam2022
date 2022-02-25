using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckPlayerOn : MemoryBase
{
    [SerializeField] protected BoxCollider2D myCollider;
    [SerializeField] protected LayerMask collidersMask;
    [SerializeField] protected Collider2D[] collidersToTurnOn;

    protected Collider2D[] toTurnOff;
    public virtual void Start()
    {

    }
    public override void OnPlaced()
    {
        toTurnOff = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, collidersMask);
        foreach (var item in toTurnOff)
        {
            item.enabled = false;
        }

        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            collidersToTurnOn[i].enabled = true;
        }
    }

    public override void OnRemoved()
    {
        foreach (var item in toTurnOff)
        {
            item.enabled = true;
        }
        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            collidersToTurnOn[i].enabled = false;
        }
    }  
}
