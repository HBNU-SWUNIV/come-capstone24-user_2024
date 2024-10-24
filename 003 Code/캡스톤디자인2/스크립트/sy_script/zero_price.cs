using UnityEngine;
using TMPro;

public class zero_price : MonoBehaviour
{
    public TextMeshProUGUI totalAmountText;

    public void ResetTotalAmount()
    {
        totalAmountText.text = "0";
    }
}
