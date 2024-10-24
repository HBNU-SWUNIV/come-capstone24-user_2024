using UnityEngine;

public class stop_taxi : MonoBehaviour
{
    public Transform targetObject;
    public float stopDistance = 5f;
    public MonoBehaviour scriptToDisable;

    private bool isDisabled = false;

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);

        if (distanceToTarget < stopDistance && !isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = false;
            isDisabled = true;
        }
        else if (distanceToTarget >= stopDistance && isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = true;
            isDisabled = false;
        }
    }
}
