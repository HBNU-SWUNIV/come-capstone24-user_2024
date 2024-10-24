using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button targetButton;  // 조작할 버튼
    public bool isButtonOn;  // 버튼의 on/off 상태

    // 버튼 클릭 시 호출될 메소드
    public void ApplyButtonState()
    {
        if (targetButton != null)
        {
            targetButton.gameObject.SetActive(isButtonOn);
        }
    }
}
