using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class InventoryRescale : MonoBehaviour
{
    public GridLayoutGroup group;
    public Canvas canvas;

    private void Update()
    {
        Debug.Log(Screen.width);
        float screenSize = Screen.width ;

        group.cellSize = new Vector2(screenSize /5.8f, screenSize /5.8f);
        group.spacing = new Vector2(screenSize * 0.2f / 8, 0);
    }

}
