using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Dialogue d in dialogues)
        {
            d.wasTalked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        Debug.Log("Interact with: " + gameObject.name);
        foreach(Dialogue d in dialogues)
        {
            if (d.wasTalked == false)
            {
                Debug.Log("Dialoguing");
                d.wasTalked = true;
                FindObjectOfType<DialogueManager>().StartDialogue(d);
                return;
            }
        }
    }
}
