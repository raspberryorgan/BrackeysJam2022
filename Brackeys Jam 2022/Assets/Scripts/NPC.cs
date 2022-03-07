using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : Interactable
{
    Transform p;
    public GameObject ui;
    public TMP_Text alert;
    Collider2D myCol;

    public Dialogue[] dialogues;
    int curDialog = 0;

    void Start()
    {
        myCol = GetComponent<Collider2D>();
        if (myCol)
        {
            myCol.isTrigger = false;
            myCol.isTrigger = true;
        }
        p = FindObjectOfType<Player>().transform;
        DeactivateUI();
        alert.text = "?";
    }
   
    public override void ActivateUI()
    {
        ui.SetActive(true);
    }
    public override void DeactivateUI()
    {
        ui.SetActive(false);
    }
    public override void Interact(Player player)
    {
        AudioManager.instance.Play(sound);
      
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[curDialog]);
        curDialog = Mathf.Clamp(curDialog + 1, 0, dialogues.Length-1);
        Debug.Log(curDialog);
        return;
    }
}
