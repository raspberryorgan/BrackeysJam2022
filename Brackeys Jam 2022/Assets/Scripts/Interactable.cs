using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{

    public string sound;
    public abstract void Interact(Player player);
    public abstract void ActivateUI();
    public abstract void DeactivateUI();
    
}
