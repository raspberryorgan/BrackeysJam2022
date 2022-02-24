using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckPlayerOn : MonoBehaviour
{
    public RealMemory memory;

    [SerializeField] BoxCollider2D myCollider;
    [SerializeField] LayerMask collidersMask;
    [SerializeField] Collider2D[] collidersToTurnOn;
    bool placed = false;

    private void Start()
    {

    }
    private void Update()
    {
        if (!placed && memory.state == MemoryState.Placed)
        {
            placed = true;
            OnPlaced();
        }
        if (placed && memory.state != MemoryState.Placed)
        {
            placed = false;
            OnRemoved();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (placed && collidersMask.Contains(collision.gameObject.layer))
        //{
        //    collision.GetComponent<Collider2D>().enabled = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collidersMask.Contains(collision.gameObject.layer))
        //{
        //    collision.GetComponent<Collider2D>().enabled = true;
        //}
    }

    Collider2D[] toTurnOff;

    void OnPlaced()
    {
        toTurnOff = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, collidersMask);
        foreach (var item in toTurnOff)
        {
            Debug.Log("APAGAR: " + item);
            item.enabled = false;
        }

        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            collidersToTurnOn[i].enabled = true;
        }
    }

    void OnRemoved()
    {
        Debug.Log("PRENDIENDO: " + toTurnOff.Length);
        foreach (var item in toTurnOff)
        {
            item.enabled = true;
        }
        for (int i = 0; i < collidersToTurnOn.Length; i++)
        {
            collidersToTurnOn[i].enabled = false;
        }
    }

  
}
