using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int inventorySize;
    [SerializeField] List<MissionItem> inventory = new List<MissionItem>();
  
    private void Start()
    {
    }
    public void AddItem(MissionItem item)
    {
        inventory.Add(item);
    }

    public void RemoveMemory(MissionItem item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
        }
    }
    public bool ContainsItem(MissionItem item)
    {
        return inventory.Contains(item);
    }
    public bool ContainsXItems(MissionItem item, int cant)
    {
        var a = 0;
        foreach (var i in inventory)
        {
            if (i.itemName == item.itemName) a += 1;
        }
        Debug.Log(a);
        return a >= cant;
    }

}
