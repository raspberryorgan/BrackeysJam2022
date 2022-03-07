using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MissionItem
{
    public bool isInRightPlace;
    public ParticleSystem particles;
 

    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
        particles.Play();
        if (isInRightPlace)
        {
            StartCoroutine(ParticlesPlayer(player));
            AudioManager.instance.Play("dig");
        }
        else
        {
            Debug.Log("WRONG PLACE");
            AudioManager.instance.Play("negation");
            //Hacer feedback de q aca no hay nada
        }
    }


    IEnumerator ParticlesPlayer(Player player)
    {
        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
        player.AddToInventory(this);
    }
}
