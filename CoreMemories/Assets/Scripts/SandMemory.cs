using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMemory : CheckPlayerOn
{
    List<Bait> baits = new List<Bait>();
    [SerializeField] LayerMask rightLocationMask;
    [SerializeField] bool isInRightLocation;
    public override void Start()
    {
        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            baits.Add(collidersToTurnOn[i].GetComponent<Bait>());
        }
    }
    public override void OnPlaced()
    {
        base.OnPlaced();


        isInRightLocation = false;
        for (int i = 0; i < toTurnOff.Length; i++)
        {
            if(rightLocationMask.Contains(toTurnOff[i].gameObject.layer))
            {
                isInRightLocation = true;
                break;
            }
        }

        if (isInRightLocation)
        {
            foreach (var b in baits)
            {
                b.transform.SetParent(transform.parent);
                b.isInRightPlace = true;
            }
        }
        else
        {
            foreach (var b in baits)
            {
                b.transform.SetParent(transform.parent);
                b.isInRightPlace = false;
            }
        }
    }

    public override void OnRemoved()
    {
        foreach (var b in baits)
        {
            b.transform.SetParent(transform);
        }
        base.OnRemoved();
    }
}
