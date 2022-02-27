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
        if (isOnRightPos && cat)
        {
            AudioManager.instance.Play(sound);

            cat.CallCat();
        }
    }


}
