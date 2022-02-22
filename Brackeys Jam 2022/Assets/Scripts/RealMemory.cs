using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMemory : MonoBehaviour
{
    public DraggableMemory draggableMemory;
    Camera cam;
    Canvas canvas;
    Player player;
    [HideInInspector]
    public MouseChecker checker;

    MemoryState state;

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
        gameObject.SetActive(false);
        state = MemoryState.Off;
        checker.AddOnMouseEnter(OnInventoryEnter);
        checker.AddOnMouseExit(OnInventoryExit);      
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

            draggableMemory.transform.position = cam.WorldToScreenPoint(transform.position);
            //Vector3 newPos = cam.ScreenToWorldPoint(draggableMemory.transform.position);
            //newPos.z = transform.position.z;
            //transform.position = newPos;
        }

        Debug.Log(state);   
    }
    void Debugger()
    {

        Debug.Log(state);
    }

    void OnInventoryEnter()
    {
        if (state == MemoryState.Selected)
        {
            state = MemoryState.Off;
            gameObject.SetActive(false);
        }
    }

    void OnInventoryExit()
    {
        if (state == MemoryState.Off)
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
}

public enum MemoryState
{
    Placed,
    PlacedInEditMode,
    Selected,
    Off

}
