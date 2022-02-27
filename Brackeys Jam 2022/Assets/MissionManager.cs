using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionManager : MonoBehaviour
{
    public Player player;
    public MissionItem coinsType;
    public Text coinsText;

    public Vector2 timer;

    void Start()
    {
        timer = new Vector2(10, 0);
    }
    private void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        timer.y += Time.deltaTime;
        if(timer.y >= 60)
        {
            timer.x++;
            timer.y = 0;
        }
    }

}
