using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemorySlot : MonoBehaviour, IDropHandler
{
    Camera cam;
    public DraggableMemory selectedMem;

    DraggableMemory[] memories;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        memories = FindObjectsOfType<DraggableMemory>();
        selectedMem = null;
        foreach (var item in memories)
        {
            if(item.state == DragState.Selected)
            {
                RectTransform currRect = item.GetComponent<RectTransform>();
                item.SetParent(transform);
                currRect.anchorMin = Vector2.zero;
                currRect.anchorMax = Vector2.one;
                currRect.anchoredPosition = Vector3.zero;
                currRect.sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;

                currRect.offsetMin = Vector2.zero;
                currRect.offsetMax = Vector2.zero;
            }
        }

        var aux = eventData.pointerDrag.GetComponent<DraggableMemory>();
        if (aux != null && aux.state == DragState.Selected)
        {
        }
    }



}