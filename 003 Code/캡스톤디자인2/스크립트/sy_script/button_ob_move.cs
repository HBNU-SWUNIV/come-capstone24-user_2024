using System.Collections;
using UnityEngine;

public class button_ob_move : MonoBehaviour
{
    public Transform targetObject;     

    public Vector3 initialPosition;       // 처음 상태
    public Vector3 initialRotation;       
    public Vector3 initialScale;          

    public Vector3 targetPosition;        // 나중
    public Vector3 targetRotation;        
    public Vector3 targetScale;           

    public float transitionDuration = 1f; // 지속 시간
    public float delayTime = 0f;          // 전 딜레이 시간

    private bool hasTriggered = false;    

    private void Start()
    {
        targetObject.position = initialPosition;
        targetObject.rotation = Quaternion.Euler(initialRotation);
        targetObject.localScale = initialScale;
    }

    public void OnButtonClick()
    {
        if (!hasTriggered) 
        {
            Debug.Log("Button clicked");
            hasTriggered = true;
            StartCoroutine(DelayedAnimation());
        }
    }

    private IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(delayTime);  // 딜레이 
        StartCoroutine(AnimateObject(targetPosition, targetRotation, targetScale));
    }

    private IEnumerator AnimateObject(Vector3 endPosition, Vector3 endRotation, Vector3 endScale)
    {
        Vector3 startPosition = targetObject.position;
        Quaternion startRotation = targetObject.rotation;
        Vector3 startScale = targetObject.localScale;

        Quaternion endRotationQuat = Quaternion.Euler(endRotation);

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            targetObject.position = Vector3.Lerp(startPosition, endPosition, t);
            targetObject.rotation = Quaternion.Lerp(startRotation, endRotationQuat, t);
            targetObject.localScale = Vector3.Lerp(startScale, endScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.position = endPosition;
        targetObject.rotation = endRotationQuat;
        targetObject.localScale = endScale;
    }
}
