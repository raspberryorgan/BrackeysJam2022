using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemorySlot : MonoBehaviour, IDropHandler
{
    Camera cam;
    RealMemory selectedMem;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROPS");

        var aux = eventData.pointerDrag.GetComponent<DraggableMemory>();
        if (aux != null && aux.state == DragState.Selected)
        {
            Debug.Log("LLEGUE ACA 2222");
            aux.SetParent(transform);
            aux.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }



}