using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class menu_camera : MonoBehaviour
{
    public float turnSpeed = 1f; 
    private float xRotate = 0.0f; 
    private float yRotate = 0.0f;

    private Vector3 initialRotation;


    void Start()
    {
        initialRotation = transform.eulerAngles;
        xRotate = initialRotation.x;
        yRotate = initialRotation.y;
    }
  
    void Update()
    {
        
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        yRotate = Mathf.Clamp(yRotate + yRotateSize, -5, 5);

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
     //    각도 제한 (하늘방향, 바닥방향)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -5, 5);

        transform.eulerAngles = new Vector3(initialRotation.x + xRotate, initialRotation.y + yRotate, 0);

    }
}
