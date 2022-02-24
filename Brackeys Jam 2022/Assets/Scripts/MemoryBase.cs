using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBase : MonoBehaviour
{
    bool placed = false;
    public RealMemory memory;
    void Update()
    {
        if (!placed && memory.state == MemoryState.Placed)
        {
            placed = true;
            OnPlaced();
        }
        if (placed && memory.state != MemoryState.Placed)
        {
            placed = false;
            OnRemoved();
        }
    }

    public virtual void OnPlaced(){ }
    public virtual void OnRemoved() { }
}
