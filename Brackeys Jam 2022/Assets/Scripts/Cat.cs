using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MissionItem
{
    public Transform initialPos;
    public Transform finalPos;
    public float travelTime;

    Animator anim;
    bool inDestination;
    float timer;
    SpriteRenderer sr;

    bool bellRang;
    public void Start()
    {
        anim = GetComponent<Animator>();
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
        AudioManager.instance.Play("meow");
        sr.enabled = true;
        bellRang = true;
    }

    void Appear()
    {
        if(timer < travelTime)
        {
            timer += Time.deltaTime;
        }else if(!inDestination)
        {
            inDestination = true;
            anim.SetBool("InDestination", true);
        }
        transform.position = Vector3.Lerp(initialPos.position, finalPos.position, timer / travelTime);

    }
}
