using System.Collections;
using UnityEngine;

public class PanelActivationMonitor : MonoBehaviour
{
    public GameObject triggerPanel;
    public Transform targetObject;

    public Vector3 initialPosition; // 처음
    public Vector3 initialRotation;
    public Vector3 initialScale;

    public Vector3 targetPosition;  // 목표 
    public Vector3 targetRotation;
    public Vector3 targetScale;

    public float transitionDuration = 1f;

    private bool isAnimating = false;
    private bool hasTriggered = false;

    private void Start()
    {
        targetObject.position = initialPosition;
        targetObject.rotation = Quaternion.Euler(initialRotation);
        targetObject.localScale = initialScale;

        // 초기 상태 감지
        StartCoroutine(CheckPanelState());
    }

    private IEnumerator CheckPanelState()
    {
        while (true)
        {
            if (triggerPanel != null && triggerPanel.activeSelf && !hasTriggered)
            {
                Debug.Log("Trigger panel activated");
                hasTriggered = true;
                StartCoroutine(AnimateObject(targetPosition, targetRotation, targetScale));
            }
            yield return null;
        }
    }

    private IEnumerator AnimateObject(Vector3 endPosition, Vector3 endRotation, Vector3 endScale)
    {
        isAnimating = true;

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

        isAnimating = false;
    }
}
