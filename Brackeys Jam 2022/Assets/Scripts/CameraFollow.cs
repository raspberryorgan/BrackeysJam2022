using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;
    }
}
