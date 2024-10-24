using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상
    public Vector3 offset ; 

    void Update()
    {
        transform.position = target.position + offset;
    }
}
