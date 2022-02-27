using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOrderInLayer : ReOrderInLayer
{
    void Update()
    {
        sr.sortingOrder = Order();
    }
}
