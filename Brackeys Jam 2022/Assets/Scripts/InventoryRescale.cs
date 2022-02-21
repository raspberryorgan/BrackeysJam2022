using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class InventoryRescale : MonoBehaviour
{
    public GridLayoutGroup group;


    private void Update()
    {
        float screenSize = Screen.width * 0.9f;

        group.cellSize = new Vector2(screenSize*0.8f  /8, screenSize*0.8f / 8);
        group.spacing = new Vector2(screenSize * 0.2f / 8, 0);
    }

}
