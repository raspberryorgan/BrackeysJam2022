using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class MouseChecker : MonoBehaviour, IDragHandler
{
    Action onMouseEnter = () => { };
    Action onMouseExit = () => { };

    bool isOverGo;
    public void AddOnMouseEnter( Action callback) { onMouseEnter += callback; }
    public void AddOnMouseExit(Action callback) { onMouseExit += callback; }

    void Awake()
    {
        Action onMouseEnter = () => { };
        Action onMouseExit = () => { };
    }
    void Update()
    {
        if (!isOverGo && EventSystem.current.IsPointerOverGameObject())
        {
            isOverGo = true;
            onMouseEnter();
        }else if( isOverGo && !EventSystem.current.IsPointerOverGameObject())
        {
            isOverGo = false;
            onMouseExit();
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        //if(eventData.)

    }
}
