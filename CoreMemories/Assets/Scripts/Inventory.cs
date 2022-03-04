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

    public MissionItem RemoveItem(MissionItem item)
    {
        foreach (var i in inventory)
        {
            if (i.itemName == item.itemName)
            {
                inventory.Remove(i);
                UIManager.instance.Refresh("Refresh" + item.itemName);
                return i;
            }
        }
        return null;
    }
    public bool ContainsItem(MissionItem item)
    {
        foreach (var i in inventory)
        {
            if (i.itemName == item.itemName) return true;
        }
        return false;
    }

    public bool ContainsXItems(MissionItem item, int cant)
    {
        var a = 0;
        foreach (var i in inventory)
        {
            if (i.itemName == item.itemName) a += 1;
        }
        return a >= cant;
    }

    public int HowManyItems(MissionItem item)
    {
        var a = 0;
        foreach (var i in inventory)
        {
            if (i.itemName == item.itemName) a += 1;
        }
        return a;
    }

}
