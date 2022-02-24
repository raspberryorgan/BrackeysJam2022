using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Mission mission;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact(Player player)
    {
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
            Debug.Log( player.objectsInventory.ContainsXItems(mission.item, mission.requiredAmount));
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
            return;
        }
        if (mission.state == MissionStates.Claimed)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[3]);
            return;
        }
        
    }
}
