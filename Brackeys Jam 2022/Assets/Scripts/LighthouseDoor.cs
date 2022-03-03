using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LighthouseDoor : Interactable
{
    public override void ActivateUI()
    {
    }

    public override void DeactivateUI()
    {
    }

    public override void Interact(Player player)
    {
        MissionItem item = new MissionItem();
        item.itemName = "Key";
        if (player.objectsInventory.ContainsItem(item))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
