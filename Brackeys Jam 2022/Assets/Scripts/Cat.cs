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
        sr.enabled = false;
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
        sr.enabled = true;
        bellRang = true;
        if (gameObject.activeSelf)
        {
            Debug.Log("CALLING CAT");
            AudioManager.instance.Play("meow");
        }
    }

    void Appear()
    {
        if (timer < travelTime)
        {
            timer += Time.deltaTime;
        }
        else if (!inDestination)
        {
            inDestination = true;
            anim.SetBool("InDestination", true);
        }
        transform.position = Vector3.Lerp(initialPos.position, finalPos.position, timer / travelTime);

    }
}
