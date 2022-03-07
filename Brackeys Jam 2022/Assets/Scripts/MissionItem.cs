using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionItem : Interactable
{
    protected SpriteRenderer sr;
    public string itemName;
    public Sprite normal;
    public Sprite interactSprite;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void ActivateUI()
    {
        if(interactSprite)
            sr.sprite = interactSprite;
    }   

    public override void DeactivateUI()
    {
        if(normal)
            sr.sprite = normal;
    }

    public override void Interact(Player player)
    {
        player.AddToInventory(this);
        gameObject.SetActive(false);
        AudioManager.instance.Play(sound);
    }
}
