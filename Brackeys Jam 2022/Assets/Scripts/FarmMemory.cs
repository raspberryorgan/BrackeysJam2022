using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmMemory : CheckPlayerOn
{
    List<Plot> plots = new List<Plot>();
    [SerializeField] LayerMask rightLocationMask;
    [SerializeField] bool isInRightLocation;
    public override void Start()
    {
        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            plots.Add(collidersToTurnOn[i].GetComponent<Plot>());
        }
    }
    public override void OnPlaced()
    {
        base.OnPlaced();


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
            foreach (var p in plots)
            {
                p.transform.SetParent(transform.parent);
                p.isInRightPlace = true;
            }
        }
        else
        {
            foreach (var p in plots)
            {
                p.transform.SetParent(transform.parent);
                p.isInRightPlace = false;
            }
        }
    }

    public override void OnRemoved()
    {
        isInRightLocation = false;
        foreach (var p in plots)
        {
            p.transform.SetParent(transform);
            p.isInRightPlace = false;
        }
    
        base.OnRemoved();
    }
}
