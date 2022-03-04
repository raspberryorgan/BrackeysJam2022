using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ReOrderInLayer : MonoBehaviour
{
    public GameObject posToCheck;
    protected SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = Order();
    }

    public int Order()
    {
        int i = 0;
        if (posToCheck)
        {
             i = 1000 - Mathf.FloorToInt(posToCheck.transform.position.y * 10);
        }
        else
        {
            i = 1000 -Mathf.FloorToInt(transform.position.y * 10);
        }
        return i;
    }
}
