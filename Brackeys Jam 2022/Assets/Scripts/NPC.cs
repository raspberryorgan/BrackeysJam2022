using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Mission mission;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        if (mission.started == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[0]);
            
        }
    }
}
