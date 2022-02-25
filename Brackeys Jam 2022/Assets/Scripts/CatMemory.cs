using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMemory : CheckPlayerOn
{
    public Bell bell;
    public Cat cat;
    [SerializeField] LayerMask rightLocationMask;
    [SerializeField] bool isInRightLocation;
    public override void Start()
    {
        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            bell = (collidersToTurnOn[i].GetComponent<Bell>());
           
        }
    }
    public override void OnPlaced()
    {
        base.OnPlaced();
        bell.cat = FindObjectOfType<Cat>();

        isInRightLocation = false;
        for (int i = 0; i < toTurnOff.Length; i++)
        {
            if (rightLocationMask.Contains(toTurnOff[i].gameObject.layer))
            {
                isInRightLocation = true;
                break;
            }
        }

        if (isInRightLocation)
        {
            bell.transform.SetParent(transform.parent);
            bell.isOnRightPos = true;
        }
        else
        {
            bell.transform.SetParent(transform.parent);
            isInRightLocation = false;
        }

    }

    public override void OnRemoved()
    {
        bell.transform.SetParent(transform);
        base.OnRemoved();
    }
}
