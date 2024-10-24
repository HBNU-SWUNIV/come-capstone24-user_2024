using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public Image targetImage;  // 조작할 이미지
    public bool isImageOn;  // 이미지의 on/off 상태

    // 버튼 클릭 시 호출될 메소드
    public void ApplyImageState()
    {
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(isImageOn);
        }
    }
}
