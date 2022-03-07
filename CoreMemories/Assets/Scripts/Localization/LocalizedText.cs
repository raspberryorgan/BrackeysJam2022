using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    public string key;
    public bool show = false;

    public bool useTMPro = true;
    private Text textComponent;
    private TMP_Text tmproComponent;

    void Start()
    {
        ChangeLanguage();
    }
    private void Update()
    {
        ChangeLanguage();
    }
    private void ChangeLanguage()
    {
        if (!useTMPro)
        {
            if (textComponent == null) textComponent = GetComponent<Text>();
            textComponent.text = Localization.Instance.TryGetText(key);
        }
        else
        {
            if (tmproComponent == null) tmproComponent = GetComponent<TMP_Text>();
            tmproComponent.text = Localization.Instance.TryGetText(key);
        }
    }



    public void OnValidate()
    {
        if (!show) return;
        if (!useTMPro)
        {
            if (textComponent == null) textComponent = GetComponent<Text>();
            textComponent.text = "[" + key + "]";
        }
        else
        {
            if (tmproComponent == null) tmproComponent = GetComponent<TMP_Text>();
            tmproComponent.text = "[" + key + "]";
        }
    }
}
