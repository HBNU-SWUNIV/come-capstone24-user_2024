using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; // 차가 따라갈 경로 포인트
    public float speed = 5f; // 차 속도
    public float rotationSpeed = 5f; //  회전 속도
    public float reachDistance = 1f; // 포인트 판단 거리
    public float stopDistance = 3f; // 멈출 기준 거리

    public GameObject[] otherCars; //다른 차들

    private int currentWaypoint = 0; 
    private Vector3 initialPosition; 
    private Quaternion initialRotation; 
    private bool isStopped = false; 

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (waypoints.Length == 0 || otherCars.Length == 0) return;

        // 가장 가까운 차량과의 거리
        bool isCarInFront = false;
        foreach (GameObject otherCar in otherCars)
        {
            if (otherCar != null && otherCar != gameObject) 
            {
                float distanceToOtherCar = Vector3.Distance(transform.position, otherCar.transform.position);
                Vector3 directionToOtherCar = (otherCar.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(transform.forward, directionToOtherCar);

                if (dotProduct > 0.5f && distanceToOtherCar < stopDistance) 
                {
                    isCarInFront = true;
                    break; 
                }
            }
        }

        // 앞에 차량이 있으면 멈춤
        if (isCarInFront)
        {isStopped = true;}
        else
        {isStopped = false;}

        if (isStopped) return;

        Transform targetWaypoint = waypoints[currentWaypoint];

        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; // 수평 방향만 고려
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
