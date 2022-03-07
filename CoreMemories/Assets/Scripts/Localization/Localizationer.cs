using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizationer : MonoBehaviour
{
    void Awake()
    {
        Localization.Instance.LoadFromJson("Assets/Languages/en_US.json");
    }
}
