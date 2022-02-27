using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MissionItem
{
    public bool isInRightPlace;

    
    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
        if (isInRightPlace)
        {
            player.AddToInventory(this);
            gameObject.SetActive(false);
            AudioManager.instance.Play("dig");
        }
        else
        {
            Debug.Log("WRONG PLACE");
            AudioManager.instance.Play("negation");
            //Hacer feedback de q aca no hay nada
        }
    }
}
