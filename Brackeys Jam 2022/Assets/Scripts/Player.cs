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

    public Animator anim;
    SpriteRenderer sr;
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
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        onOpenInventory = () => { };
        onCloseInventory = () => { };
        UIManager.instance.ResetUI();
    }

    void Update()
    {
        if (isBusy)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Move();
        InteractPos();


        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DreamInventoryChange();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.instance.OpenCloseInventory();
        }
    }


    void DreamInventoryChange()
    {
        if (memoryInventory.activeSelf) onCloseInventory();
        else
            onOpenInventory();
        memoryInventory.SetActive(!memoryInventory.activeSelf);
    }

    void TryInteract()
    {
        var item = Physics2D.CircleCast(interactPos.position, .2f, Vector2.zero, interactableMask);
        if (item.transform != null)
        {
            var interactable = item.transform.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }
    }

    Interactable lastInteractable;
    void InteractPos()
    {
        interactPos.position = transform.position + lastDir;
        if (lastInteractable != null)
            Debug.Log(lastInteractable.gameObject.name);
        else
            Debug.Log(lastInteractable);

        var item = Physics2D.CircleCast(interactPos.position, .2f, Vector2.zero, interactableMask);
        if (item.transform != null)
        {
            var interactable = item.transform.GetComponent<Interactable>();
            if (interactable != lastInteractable && lastInteractable != null)
            {
                lastInteractable.DeactivateUI();
                lastInteractable = null;
            }
            else if (interactable != null && interactable != lastInteractable)
            {
                lastInteractable = interactable;
                interactable.ActivateUI();
            }
        }
        else if (lastInteractable != null)
        {
            lastInteractable.DeactivateUI();
            lastInteractable = null;
        }
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
            sr.flipX = Input.GetAxisRaw("Horizontal") < 0;
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

        anim.SetBool("IsMoving", rb.velocity.magnitude > 0.1f);

        anim.SetFloat("HorSpeed", lastDir.x);
        anim.SetFloat("VertSpeed", lastDir.y);
    }


    public void AddToInventory(MissionItem item)
    {
        objectsInventory.AddItem(item);
        UIManager.instance.Refresh("Refresh" + item.itemName);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactPos.position, 0.2f);
    }
}
