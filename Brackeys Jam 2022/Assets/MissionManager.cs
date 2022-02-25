using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionManager : MonoBehaviour
{
    public Player player;
    public MissionItem coinsType;
    public Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinsUI(player.objectsInventory.HowManyItems(coinsType));
    }

    void UpdateCoinsUI(float val)
    {
        coinsText.text = val+ "/5";
    }
}
