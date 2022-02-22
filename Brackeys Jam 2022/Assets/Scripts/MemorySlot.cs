using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemorySlot : MonoBehaviour, IDropHandler
{
    Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (GetComponentInChildren<DraggableMemory>()) return;

        var aux = eventData.pointerDrag.GetComponent<DraggableMemory>();
        if (aux!= null)
        {
            aux.SetParent(transform);            
        }
    }
}