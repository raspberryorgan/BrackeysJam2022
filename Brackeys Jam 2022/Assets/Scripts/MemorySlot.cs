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
                item.SetParent(transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
              
            }
        }

        var aux = eventData.pointerDrag.GetComponent<DraggableMemory>();
        if (aux != null && aux.state == DragState.Selected)
        {
        }
    }



}