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
        var aux = eventData.pointerDrag.GetComponent<DraggableMemory>();
        if (aux!= null)
        {
            aux.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
}