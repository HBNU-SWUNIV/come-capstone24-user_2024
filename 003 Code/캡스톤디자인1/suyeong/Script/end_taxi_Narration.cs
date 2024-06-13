using UnityEngine;
using TMPro;
using System.Collections;

public class end_taxi_Narration : MonoBehaviour
{
    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    // public GameObject targetObject; //택시가 될 예정
    // public float delayTime = 2.0f;

    public GameObject targetObject;
    public float delayTime = 0f;

    public TextMeshProUGUI narrationText;
    public GameObject narrationPanel;

    private int currentIndex = 0;
    public string[] textArray = new string[] {
        "A taxi will come, so don't move and wait!"
    };

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentIndex < textArray.Length)
            {
                narrationText.text = textArray[currentIndex];
                currentIndex++; 
            }
            else //나레이션 끝
            {
                narrationPanel.SetActive(false);
                targetScript1.enabled = true;
                targetScript2.enabled = true;

                // Invoke("ActivateTargetObject", delayTime); 
                Invoke("ActivateTargetObject", delayTime);
            }
        }
    }

    void ActivateTargetObject()
    {
        //     if (targetObject != null) // 택시 추가 후 사용
        //     {
        //         targetObject.SetActive(true); //택시 소환
        //         // Debug.Log(targetObject.name + " has been activated.");
        //     }

        if (targetObject != null)
        {
            targetObject.SetActive(false); // 핸드폰 비활성화
        }
    }
}
