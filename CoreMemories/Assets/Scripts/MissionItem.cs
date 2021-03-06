using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionItem : Interactable
{
    public string itemName;

    public override void ActivateUI()
    {
    }

    public override void DeactivateUI()
    {       
    }

    public override void Interact(Player player)
    {
        player.AddToInventory(this);
        gameObject.SetActive(false);
        AudioManager.instance.Play(sound);
    }
}
