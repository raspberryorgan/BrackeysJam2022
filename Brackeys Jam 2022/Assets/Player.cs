using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            rb.velocity = (Vector2.up * speed * Input.GetAxis("Vertical")).normalized;
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            rb.velocity = (Vector2.right * speed * Input.GetAxis("Horizontal")).normalized;
        else rb.velocity = Vector2.zero;

    }
}
