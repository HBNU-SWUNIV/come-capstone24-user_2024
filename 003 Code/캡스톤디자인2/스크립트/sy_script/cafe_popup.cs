using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Text.RegularExpressions;  

public class cafe_popup : MonoBehaviour
{
    public GameObject popupPanel;    // 팝업창 
    public TextMeshProUGUI popupMenuName;  //  메뉴 이름
    public TextMeshProUGUI popupPrice;     //  가격
    public Button[] menuButtons;     // 메뉴 버튼ㄴ들

    public GameObject canvasToToggle; // 메뉴 옵션창
    public Button cancelButton;      // 닫기

    void Start()
    {
        foreach (Button button in menuButtons)
        {
            button.onClick.AddListener(() => ShowMenuDetails(button.gameObject));
        }

        cancelButton.onClick.AddListener(ClosePopup);
    }

    public void ShowMenuDetails(GameObject menuButton)
    {
        TextMeshProUGUI buttonMenuName = menuButton.transform.Find("menu_name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI buttonPrice = menuButton.transform.Find("price").GetComponent<TextMeshProUGUI>();

        popupMenuName.text = buttonMenuName.text;
        string priceString = Regex.Replace(buttonPrice.text, @"\D", ""); 
        popupPrice.text = priceString;


        popupPanel.SetActive(true);
        if (canvasToToggle != null)
        {canvasToToggle.SetActive(true);}
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
        if (canvasToToggle != null)
        {
            canvasToToggle.SetActive(false);
        }
    }
}
