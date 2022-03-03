using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clay : Interactable
{
    public Mission mission;
    Transform p;
    public GameObject ui;
    public GameObject alert;
    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, p.position) < 2)
        {
            ui.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }
    }
    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
        if (mission.state == MissionStates.NotActivated)
        {
            mission.Init();
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[0]);
            FindObjectOfType<UIManager>().ShowMainMission();
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
            for (int i = 0; i < mission.requiredAmount; i++)
            {
                player.objectsInventory.RemoveItem(mission.item);
                UIManager.instance.Refresh("Refresh" + mission.item.itemName);
            }
            mission.state = MissionStates.Claimed;
            player.AddToInventory(mission.award);
            AudioManager.instance.Play("award");
            alert.SetActive(false);
            return;
        }
        if (mission.state == MissionStates.Claimed)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(mission.dialogues[3]);
            return;
        }

    }

    public override void ActivateUI()
    {
    }

    public override void DeactivateUI()
    {
    }
}
