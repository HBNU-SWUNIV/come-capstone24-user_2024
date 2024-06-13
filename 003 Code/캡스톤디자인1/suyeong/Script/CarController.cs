using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; //경로들

    public float speed = 5f;
    public float rotationSpeed = 5f;

    public float reachDistance = 1f;
    private int currentWaypoint = 0;

    private Vector3 initialPosition; // 처음 위치
    private Quaternion initialRotation; // 처음 방향

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypoint];

        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; 
        Vector3 moveDirection = direction.normalized * speed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < reachDistance)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                transform.position = initialPosition;
                transform.rotation = initialRotation;
                currentWaypoint = 0;
            }
        }
    }
}
