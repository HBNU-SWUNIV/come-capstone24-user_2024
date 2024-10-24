using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject targetButton; // 활성화할 타겟 버튼 9999999999999999999
    public GameObject narrationPanel;

    public void OnButtonClick()
    {
        if (targetButton != null)
        {
            targetButton.SetActive(true); // 타겟 버튼 활성화
        }
        gameObject.SetActive(false); // 현재 버튼 비활성화
    }

    public void End_Narration()
    {
        gameObject.SetActive(false); // 버튼 비활성화
        narrationPanel.SetActive(true); // Panel 활성화
    }
}
