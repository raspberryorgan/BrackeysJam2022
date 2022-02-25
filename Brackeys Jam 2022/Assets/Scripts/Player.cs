using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    Rigidbody2D rb;
    public bool isBusy;

    Vector3 lastDir;
    public Transform interactPos;
    public LayerMask interactableMask;
    public GameObject memoryInventory;
    public Inventory objectsInventory;

    public float stepTime;
    private float soundTime;

    Action onOpenInventory = () => { };
    Action onCloseInventory = () => { };

    public void AddOnOpenInventory(Action callback) { onOpenInventory += callback; }
    public void RemoveOnOpenInventory(Action callback) { onOpenInventory -= callback; }
    public void AddOnCloseInventory(Action callback) { onCloseInventory += callback; }
    public void RemoveOnCloseInventory(Action callback) { onCloseInventory -= callback; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onOpenInventory = () => { };
        onCloseInventory = () => { };
    }

    void Update()
    {
        if (isBusy) {
            rb.velocity = Vector2.zero;
            return; }
        Move();
        InteractPos();


        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryChange();
        }
    }


    void InventoryChange()
    {
        if (memoryInventory.activeSelf) onCloseInventory();
        else
            onOpenInventory();
        memoryInventory.SetActive(!memoryInventory.activeSelf);
    }
    void TryInteract()
    {
        var aux = Physics2D.CircleCastAll(interactPos.position, .2f, Vector2.zero, interactableMask);
        foreach (var item in aux)
        {
            if (item.transform != null)
            {
                var interactable = item.transform.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                }
            }
        }
    }
    void InteractPos()
    {
        interactPos.position = transform.position + lastDir;
    }

    void Move()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            rb.velocity = (Vector2.up * Input.GetAxisRaw("Vertical")).normalized * speed;
            lastDir = new Vector2(0, Input.GetAxisRaw("Vertical"));
            soundTime += Time.deltaTime;
            if (soundTime > stepTime)
            {
                AudioManager.instance.PlayStep();
                soundTime = 0;
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            rb.velocity = (Vector2.right * Input.GetAxisRaw("Horizontal")).normalized * speed;
            lastDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            soundTime += Time.deltaTime;
            if (soundTime > stepTime)
            {
                AudioManager.instance.PlayStep();
                soundTime = 0;
            }
        }
        else rb.velocity = Vector2.zero;
    }

    public void AddToInventory(MissionItem item)
    {
        objectsInventory.AddItem(item);
    }
}
