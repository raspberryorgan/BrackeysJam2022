using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interactable
{
    public bool isOnRightPos;
    public Cat cat;
    void Start()
    {

    }

    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
        if (isOnRightPos && cat)
        {
            cat.CallCat();
        }
    }

    public override void ActivateUI()
    {
    }

    public override void DeactivateUI()
    {
    }
}
