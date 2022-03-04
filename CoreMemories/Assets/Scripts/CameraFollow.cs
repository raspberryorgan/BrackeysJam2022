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
        transform.position = new Vector3(Mathf.Clamp(targetPos.x,-16,23), Mathf.Clamp(targetPos.y,-15,23), targetPos.z);
    }
}
