using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class MouseChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Action onMouseEnter = () => { };
    Action onMouseExit = () => { };
    Action ONUPDATE = () => { };

    bool isOverGo;
    public void ADDONUPDATE(Action callback) { ONUPDATE += callback; }
    public void AddOnMouseEnter( Action callback) { onMouseEnter += callback; }
    public void AddOnMouseExit(Action callback) { onMouseExit += callback; }

    void Awake()
    {
        Action onMouseEnter = () => { };
        Action onMouseExit = () => { };
    }
    void Update()
    {
        //ONUPDATE();
        if (!isOverGo && EventSystem.current.IsPointerOverGameObject())
        {
        }else if( isOverGo && !EventSystem.current.IsPointerOverGameObject())
        {
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOverGo = true;
        onMouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOverGo = false;
        onMouseExit();
    }
}
