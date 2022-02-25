using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : Interactable
{
    public Seed seed;

    public override void Interact(Player player)
    {
        if (player.objectsInventory.ContainsItem(seed))
        {
            Debug.Log("LO CONTIENE");
            player.objectsInventory.RemoveItem(seed);
            PlantSeed();
        }
        else
            Debug.Log("NO CONTIENE");
    }

   
    public void PlantSeed()
    {
        Debug.Log("SEMILLA PLANTADA");
    }
}
