using System.Collections;
using UnityEngine;

public class toggle_move_2d : MonoBehaviour
{
    public RectTransform targetObject;   
    public Vector2 positionA;            // A 위치
    public Vector2 positionB;            // B 위치
    public float moveDuration = 1f;

    private bool isAtPositionA = true;   // 현재 위치가 A인지 여부

    public void OnButtonClick()
    {
        Vector2 targetPosition = isAtPositionA ? positionB : positionA;
        StartCoroutine(MoveObject(targetPosition));

        isAtPositionA = !isAtPositionA;
    }
    private IEnumerator MoveObject(Vector2 targetPosition)
    {
        Vector2 startPosition = targetObject.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            targetObject.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.anchoredPosition = targetPosition;
    }
}
