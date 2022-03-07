using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizationer : MonoBehaviour
{
    void Start()
    {
        Localization.Instance.LoadFromJson("Assets/Languages/en_US.json");
    }
}
