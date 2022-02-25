using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MissionItem
{
    public Transform initialPos;
    public Transform finalPos;
    public float travelTime;
    float timer;
    SpriteRenderer sr;

    bool bellRang;
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    public override void Interact(Player player)
    {
        player.AddToInventory(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (bellRang)
        {
            Appear();
        }
        
    }
    public void CallCat()
    {
        Debug.Log("CALLING CAT");
        sr.enabled = true;
        bellRang = true;
    }

    void Appear()
    {
        timer += Time.deltaTime;

        transform.position = Vector3.Lerp(initialPos.position, finalPos.position, timer / travelTime);

    }
}
