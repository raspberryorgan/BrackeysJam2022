using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrot : MissionItem
{
    public float growTime;

    public bool harvestReady;
    float growtimer = 0;
    public Sprite[] sprites;
    SpriteRenderer sr;
    public Image bg;
    public Image fillAmount;
    public string negationSound;
    [HideInInspector] public Plot plot;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!harvestReady)
        {
            growtimer += Time.deltaTime;
            Debug.Log(Mathf.FloorToInt((growtimer / growTime) * (sprites.Length - 1)));
            sr.sprite = sprites[Mathf.FloorToInt((growtimer / growTime) * (sprites.Length - 1))];

            fillAmount.fillAmount = growtimer / growTime;

            if (growtimer >= growTime)
            {
                bg.gameObject.SetActive(false);
                fillAmount.gameObject.SetActive(false);
                harvestReady = true;
            }
        }
    }

    public override void Interact(Player player)
    {
        if (harvestReady)
        {
            player.AddToInventory(this);
            gameObject.SetActive(false);
            AudioManager.instance.Play(sound);

            plot.hasPlant = false;
        }
        else
        {

            AudioManager.instance.Play(negationSound    );
        }

    }
}
