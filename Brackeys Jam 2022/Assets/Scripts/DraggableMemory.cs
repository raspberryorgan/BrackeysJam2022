using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableMemory : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    RectTransform rectTransform;
     [HideInInspector] public CanvasGroup canvasGroup;

    Transform lastParent;
    public RealMemory realMemory;
    [HideInInspector]
    public MouseChecker checker;

    public DragState state;

    void Awake()
    {

    }
    public void Initialize(MouseChecker _checker)
    {
        checker = _checker;//TODO: CAMBIARLO A ASIGNAR CUANDO SE INSTANCIA TODO
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        realMemory.draggableMemory = this;
        checker.AddOnMouseEnter(OnInventoryEnter);
        checker.AddOnMouseExit(OnInventoryExit);
        checker.ADDONUPDATE(debugger);
        state = DragState.OnRealMemory;
        gameObject.SetActive(false);
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

    void Update()
    {
        if (state == DragState.Selected)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        }

        if (Input.GetMouseButtonUp(0) && state == DragState.Selected)
        {

            //PointerEventData ped = new PointerEventData(null);
            //ped.position = Input.mousePosition;
            //List<RaycastResult> results = new List<RaycastResult>();
            //gr.Raycast(ped, results);
            //Debug.Log(results.Count);

            canvasGroup.blocksRaycasts = true;
            if (lastParent != null && lastParent.GetComponent<MemorySlot>() != null)
            {
                rectTransform.anchoredPosition = Vector2.zero;
            }
            
            state = DragState.OnInventory;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (state == DragState.OnInventory)
        {
            canvasGroup.blocksRaycasts = false;
            state = DragState.Selected;
        }
    }

    void debugger()
    {
        Debug.Log("DRAGGABLE: "+state);
    }
  

    void OnInventoryEnter()
    {
        if (realMemory.state == MemoryState.Selected && state == DragState.OnRealMemory)
        {
            Vector3 aux = Camera.main.WorldToScreenPoint( realMemory.transform.position);
            transform.position = new Vector3(aux.x, aux.y, transform.position.z);
            gameObject.SetActive(true);
            state = DragState.Selected;
            realMemory.OnInventoryEnter();
            canvasGroup.blocksRaycasts = false;
        }
    }

    void OnInventoryExit()
    {
        if (state == DragState.Selected && realMemory.state == MemoryState.OnInventory )
        {
            state = DragState.OnRealMemory;
            realMemory.OnInventoryExit();
            gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData) { }
    public void OnBeginDrag(PointerEventData eventData) { }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData) { }
}

public enum DragState
{
    OnInventory,
    Selected,
    OnRealMemory
}


