using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission 
{
    public MissionType type;
    public Dialogue[] dialogues = new Dialogue[4];
    public GameObject award;
    public bool started;
    public bool complete;
    public virtual void Init()
    {
        foreach (Dialogue d in dialogues)
        {
            d.wasTalked = false;
        }
    }
}
public enum MissionType
{
    KillEnemies,
    Collect

}
