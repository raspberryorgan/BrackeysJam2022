using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission 
{
    public MissionType type;
    public Dialogue[] dialogues = new Dialogue[4];
    public MissionItem award;
    public MissionStates state = MissionStates.NotActivated;
    public int currentAmount;
    public int requiredAmount;
    public MissionItem item;
    public virtual void Init()
    {
        foreach (Dialogue d in dialogues)
        {
            d.wasTalked = false;
        }
    }
    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            state = MissionStates.Completed;
        }
    }
}
public enum MissionType
{
    KillEnemies,
    Collect

}
public enum MissionStates
{
    NotActivated,
    InProgress,
    Completed,
    Claimed
}