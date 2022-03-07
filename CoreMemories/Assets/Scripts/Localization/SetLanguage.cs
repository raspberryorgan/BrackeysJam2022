using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLanguage : MonoBehaviour {

    public void SetFromPath(string path)
    {
        Localization.Instance.LoadFromJson("Assets/Languages/" + path + ".json");
    }

}
