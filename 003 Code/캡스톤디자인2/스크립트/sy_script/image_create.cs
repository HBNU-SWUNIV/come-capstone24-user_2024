using UnityEngine;
using UnityEngine.UI;

public class PopupImageUpdater : MonoBehaviour
{
    public Image displayImage;  // 빈 이미지 
    public Button[] menuButtons;  
    public Button confirmButton;  // 선택 완료
    private Image selectedMenuImage;  // 클릭한 버튼의 menu_image를 저장

    void Start()
    {
        foreach (Button button in menuButtons)
        {
            button.onClick.AddListener(() => SelectMenuImage(button.gameObject));
        }

        if (confirmButton != null)
        {
            confirmButton.onClick.AddListener(ApplySelectedImage);
        }
    }

    public void SelectMenuImage(GameObject menuButton)
    {
        Image buttonMenuImage = menuButton.transform.Find("menu_Image").GetComponent<Image>();

        if (buttonMenuImage != null)
        {
            selectedMenuImage = buttonMenuImage;
        }
    }

    public void ApplySelectedImage()
    {
        if (selectedMenuImage != null)
        {
            displayImage.sprite = selectedMenuImage.sprite;
            displayImage.color = Color.white;
        }
    }
}
