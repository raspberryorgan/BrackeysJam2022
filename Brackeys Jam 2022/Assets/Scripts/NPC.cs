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
    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
        if (mission.state == MissionStates.NotActivated)
        {
            mission.Init();
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[0]);
            mission.dialogues[0].wasTalked = true;
            mission.state = MissionStates.InProgress;
            return;
        }
        if (mission.state == MissionStates.InProgress)
        {
            //Cosas de cambiar la mision a completed
            if (player.objectsInventory.ContainsXItems(mission.item, mission.requiredAmount))
            {
                mission.state = MissionStates.Completed;
            }
            else
            {

                FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[1]);
                return;
            }

        }
        
        if (mission.state == MissionStates.Completed)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[2]);
            mission.state = MissionStates.Claimed;
            player.AddToInventory(mission.award);
            AudioManager.instance.Play("award");
            return;
        }
        if (mission.state == MissionStates.Claimed)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[3]);
            return;
        }
        
    }
}
