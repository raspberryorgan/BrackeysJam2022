using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RealMemory : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public DraggableMemory draggableMemory;
    Camera cam;
    Canvas canvas;
    Player player;
    [HideInInspector]
    public MouseChecker checker;

    public MemoryState state { get; private set; } 

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        canvas = FindObjectOfType<Canvas>();
        player = FindObjectOfType<Player>();
        player.AddOnOpenInventory(StartEditing);
        player.AddOnCloseInventory(EndEditting);

        checker = FindObjectOfType<MouseChecker>();//TODO: CAMBIARLO A ASIGNAR CUANDO SE INSTANCIA TODO
    }
    void Start()
    {
        //gameObject.SetActive(false);
        checker.AddOnMouseEnter(OnInventoryEnter);
        checker.AddOnMouseExit(OnInventoryExit);
        state = MemoryState.Placed;
        checker.ADDONUPDATE(debugger);
    }
    void debugger()
    {
        Debug.Log("REAL: " + state);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (state == MemoryState.PlacedInEditMode && Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject == GetComponent<Collider2D>())
            {
                state = MemoryState.Selected;
                draggableMemory.state = DragState.Selected;
            }
        }
        if (Input.GetMouseButtonUp(0) && state == MemoryState.Selected)
        {
            state = MemoryState.PlacedInEditMode;
        }

        if (state == MemoryState.Selected)
        {
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            //targetObject.transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0); 

            //draggableMemory.transform.position = cam.WorldToScreenPoint(transform.position);
            //Vector3 newPos = cam.ScreenToWorldPoint(draggableMemory.transform.position);
            //newPos.z = transform.position.z;
            //transform.position = newPos;
        }
    }
    void OnInventoryEnter()
    {
        if (state == MemoryState.Selected)
        {
            gameObject.SetActive(false);
        }
    }

    void OnInventoryExit()
    {
        if (draggableMemory.state == DragState.Selected)
        {
            gameObject.SetActive(true);
            state = MemoryState.Selected;
        }
    }

    void StartEditing()
    {
        if (state == MemoryState.Placed)
        {
            state = MemoryState.PlacedInEditMode;
        }
    }
    void EndEditting()
    {
        if (state == MemoryState.PlacedInEditMode)
            state = MemoryState.Placed;
        else if (state == MemoryState.Selected)
        {
            state = MemoryState.Placed;
        }
    }

    public void SetState(MemoryState _state)
    {
        state = _state;
    }
      

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) { }
    public void OnEndDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }
}

public enum MemoryState
{
    Placed,
    PlacedInEditMode,
    Selected

}
