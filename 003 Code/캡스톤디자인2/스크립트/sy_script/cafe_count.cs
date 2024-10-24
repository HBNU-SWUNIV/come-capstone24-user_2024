using UnityEngine;
using TMPro;  
using UnityEngine.UI;  

public class QuantityControl : MonoBehaviour
{
    public TMP_Text countText;  // 갯수
    public Button minusButton;  // -
    public Button plusButton;   // +
    public int minValue = 1;    // 최소 갯수
    public int maxValue = 10;   // 최대 갯수

    private int currentCount;   // 현재 갯수

    private void Start()
    {
        minusButton.onClick.AddListener(OnMinusButtonClick);
        plusButton.onClick.AddListener(OnPlusButtonClick);

        // 초기 갯수를 텍스트로 설정
        //currentCount = int.Parse(countText.text);
        //UpdateCountText();
    }

    public void OnMinusButtonClick()
    {
        if (currentCount > minValue)  
        {
            currentCount--;
            UpdateCountText();
        }
    }

    public void OnPlusButtonClick()
    {
        if (currentCount < maxValue)  
        {
            currentCount++;
            UpdateCountText();
        }
    }

    // 텍스트에 갯수 업뎃
    private void UpdateCountText()
    {
        countText.text = currentCount.ToString();
    }
}