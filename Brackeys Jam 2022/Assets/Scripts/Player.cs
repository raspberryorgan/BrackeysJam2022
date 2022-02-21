using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    Rigidbody2D rb;

    Vector3 lastDir;
    public Transform interactPos;
    public LayerMask interactableMask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        InteractPos();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        var aux = Physics2D.CircleCast(interactPos.position, .2f, Vector2.zero, interactableMask);
        if (aux.transform != null)
        {
            var interactable = aux.transform.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
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
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            rb.velocity = (Vector2.right * Input.GetAxisRaw("Horizontal")).normalized * speed;
            lastDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
        else rb.velocity = Vector2.zero;
    }
}
