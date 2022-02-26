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
    }
    public void RefreshCoin(int c)
    {
        coinText.text = c.ToString();
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
