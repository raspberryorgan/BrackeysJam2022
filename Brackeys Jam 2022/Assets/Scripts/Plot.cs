using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : Interactable
{
    public bool hasPlant;
    public Seed seed;
    Carrot carr;
    public override void Interact(Player player)
    {
        if (!hasPlant && player.objectsInventory.ContainsItem(seed))
        {
            Debug.Log("LO CONTIENE");

            seed = player.objectsInventory.RemoveItem(seed).GetComponent<Seed>();
            PlantSeed();
        }
        else
            Debug.Log("NO CONTIENE");
    }


    private void Update()
    {
        if(carr != null)
        {
            carr.bg.transform.position = carr.fillAmount.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
        }
    }

    public void PlantSeed()
    {
        hasPlant = true;
        carr = seed.carrot;
        carr.transform.SetParent(transform);

        carr.gameObject.SetActive(true);

        carr.plot = this;
        carr.transform.position = transform.position;

        AudioManager.instance.Play(sound);

        Debug.Log("SEMILLA PLANTADA");
    }
}
