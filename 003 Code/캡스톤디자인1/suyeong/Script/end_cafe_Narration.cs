using UnityEngine;
using TMPro;
using System.Collections;

public class end_cafe_Narration : MonoBehaviour
{
    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    public GameObject targetObject;
    public float delayTime = 2.0f;

    public TextMeshProUGUI narrationText;
    public GameObject narrationPanel;

    private int currentIndex = 0;
    public string[] textArray = new string[] {
        "Look around the store until the drinks come out",
        "Thank you for your hard work!"
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
            else //나레이션 끝나면
            {
                narrationPanel.SetActive(false);

                targetScript1.enabled = true;
                targetScript2.enabled = true;

                Invoke("ActivateTargetObject", delayTime);
            }
        }
    }

    void ActivateTargetObject()
    {
        if (targetObject != null)
        {targetObject.SetActive(true);}
    }
}
