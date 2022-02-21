using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int inventorySize;
    [SerializeField] MemorySlot[] myMemories;


    private void Start()
    {
        myMemories = new MemorySlot[inventorySize];
    }
    public void AddMemory(MemorySlot memory)
    {
        for (int i = 0; i < myMemories.Length; i++)
        {
            if (myMemories[i] == memory) return;

        }

        for (int i = 0; i < myMemories.Length; i++)
        {
            if(myMemories[i] == null)
            {
                myMemories[i] = memory;
                return;
            }
        }
    }

    public void RemoveMemory()
    {

    }
}
