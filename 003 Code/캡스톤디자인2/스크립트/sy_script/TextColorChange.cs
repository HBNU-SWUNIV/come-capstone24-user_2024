using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColorChange : MonoBehaviour
{
    public Toggle myToggle;
    public TextMeshProUGUI labelText;

    public Color onColor = Color.green;
    public Color offColor = Color.black;

    void Start()
    {
        UpdateLabelColor(myToggle.isOn);

        myToggle.onValueChanged.AddListener(delegate { UpdateLabelColor(myToggle.isOn); });
    }

    void UpdateLabelColor(bool isOn)
    {
        labelText.color = isOn ? onColor : offColor;
    }
}
