using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOrderInLayer : ReOrderInLayer
{
    public LayerMask forMemories;
    bool onMemory;
    void Update()
    {
        sr.sortingOrder = Order();

        if (onMemory) sr.sortingOrder = 5 * Order() + 10;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (forMemories.Contains(collision.gameObject.layer))
        {
            onMemory = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (forMemories.Contains(collision.gameObject.layer))
        {
            onMemory = false;
        }
    }
}
