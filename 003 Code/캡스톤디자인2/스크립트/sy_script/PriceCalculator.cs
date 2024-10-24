using UnityEngine;
using TMPro;
public class PriceCalculator : MonoBehaviour
{
    public TMP_Text totalText;
    public TMP_Text priceText;
    public TMP_Text countText;

    public void OnConfirmButtonClick()
    {
        int price = 1;
        int count = 1;

        if (int.TryParse(priceText.text, out price) && int.TryParse(countText.text, out count))
        {
            int newTotal = price * count;
            totalText.text = newTotal.ToString();
        }
    }
}
