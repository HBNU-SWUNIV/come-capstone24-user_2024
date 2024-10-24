using UnityEngine;
using TMPro;

public class start_Narration : MonoBehaviour
{

    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    public TextMeshProUGUI narrationText;
    public GameObject narrationPanel;          // 패널
    public GameObject button;                  // 버튼
    public TextMeshProUGUI[] textArray;
    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentIndex < textArray.Length)
            {
                narrationText.text = textArray[currentIndex].text;
                currentIndex++;
            }
            else
            {
                narrationPanel.SetActive(false);

                if (targetScript1 != null) targetScript1.enabled = true;
                if (targetScript2 != null) targetScript2.enabled = true;

                if (button != null) button.SetActive(true);

            }
        }
    }
}
