using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text coinText;

    public Animator itemPanel;

    public GameObject flowerBox;
    public TMP_Text flowerText;

    public GameObject baitBox;
    public TMP_Text baitText;

    public GameObject seedsBox;
    public TMP_Text seedsText;

    public GameObject carrotBox;
    public TMP_Text carrotText;

    public GameObject keyBox;

    public TMP_Text hourText;
    public GameObject[] toHide;

    public MissionManager misionManager;


    public Player player;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        UIManager.instance.Refresh("RefreshCoin");
    }
    private void Update()
    {
        RefreshHour();
    }
    public void Refresh(string functionName)
    {
        Invoke(functionName, 0);
    }
    void RefreshCoin()
    {
        MissionItem item = new MissionItem();
        item.itemName = "Coin";
        Debug.Log("RefreshCoins");
        //StartCoroutine(AnimatePanel());
        coinText.text = player.objectsInventory.HowManyItems(item).ToString() + "/4";
    }
    void RefreshFlower()
    {
        MissionItem item = new MissionItem();
        item.itemName = "Flower";
        flowerBox.SetActive(true);
        Debug.Log("RefreshFlowers");
        StartCoroutine(AnimatePanel());
        flowerText.text = player.objectsInventory.HowManyItems(item).ToString();
    }
    void RefreshBait()
    {
        MissionItem item = new MissionItem();
        item.itemName = "Bait";
        baitBox.SetActive(true);
        Debug.Log("RefreshBait");
        StartCoroutine(AnimatePanel());
        baitText.text = player.objectsInventory.HowManyItems(item).ToString();
    }
    void RefreshSeed()
    {
        MissionItem item = new MissionItem();
        item.itemName = "Seed";
        seedsBox.SetActive(true);
        Debug.Log("RefreshSeeds");
        StartCoroutine(AnimatePanel());
        seedsText.text = player.objectsInventory.HowManyItems(item).ToString();
    }
    void RefreshCarrot()
    {
        MissionItem item = new MissionItem();
        item.itemName = "Carrot";
        carrotBox.SetActive(true);
        Debug.Log("RefreshCarrots");
        StartCoroutine(AnimatePanel());
        carrotText.text = player.objectsInventory.HowManyItems(item).ToString();
    }
    void RefreshKey()
    {
        Debug.Log("RefreshKey");
        keyBox.SetActive(true);
    }
    public void ShowMainMission()
    {
        foreach (var item in toHide)
        {
            item.SetActive(true);
        }
    }

    void RefreshHour()
    {
        hourText.text = (double)misionManager.timer.x + ":" + Mathf.FloorToInt(misionManager.timer.y).ToString("00");
    }

    bool inventoryState = false;
    public void OpenCloseInventory()
    {
        inventoryState = !inventoryState;
        itemPanel.SetBool("isOpen", inventoryState);
    }
    IEnumerator AnimatePanel()
    {
        inventoryState = true;
        itemPanel.SetBool("isOpen", inventoryState);
        yield return new WaitForSeconds(3);
        inventoryState = false;
        itemPanel.SetBool("isOpen", inventoryState);
    }

    public void ResetUI()
    {
        coinText.text = "0";
        flowerText.text = "0";
        baitText.text = "0";
        seedsText.text = "0";
        carrotText.text = "0";
        itemPanel.SetBool("isOpen", false);

    }
}
