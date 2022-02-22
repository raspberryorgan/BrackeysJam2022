using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableMemory : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    Transform lastParent;
    public RealMemory realMemory;
    [HideInInspector]
    public MouseChecker checker;

    void Awake()
    {
        checker = FindObjectOfType<MouseChecker>();//TODO: CAMBIARLO A ASIGNAR CUANDO SE INSTANCIA TODO

    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        realMemory.draggableMemory = this;
        checker.AddOnMouseEnter(OnInventoryEnter);
        checker.AddOnMouseExit(OnInventoryExit);
    }
    public void SetMemory(RealMemory _memory)
    {
        realMemory = _memory;
    }
    public void SetParent(Transform par, bool wPosStays = true)
    {
        lastParent = par;
        transform.SetParent(par, wPosStays);
    }
    public void SetCanvas(Canvas can)
    {
        canvas = can;
    }

    #region DragThings
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        realMemory.SetState(MemoryState.Off);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if(lastParent != null && lastParent.GetComponent<MemorySlot>()!= null)
        {
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    #endregion

    void OnInventoryEnter()
    {
        gameObject.SetActive(true);
    }

    void OnInventoryExit()
    {
        gameObject.SetActive(false);
    }
}


