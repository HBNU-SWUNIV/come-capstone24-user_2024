using UnityEngine;
using TMPro; 

public class start_cafe_Narration : MonoBehaviour
{
    public TextMeshProUGUI narrationText;
    public GameObject narrationPanel;
    private int currentIndex = 0;
    public GameObject button;
    public string[] textArray = new string[] {
        "Follow me and try to learn how to use it by pressing the button that pops up on top of the kiosk!",
        "Shall we start by simply ordering the menu?",
        "Let's order the iced americano first!"
    };

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentIndex < textArray.Length)
            {
                narrationText.text = textArray[currentIndex];
                currentIndex++;
            }
            else
            {
                narrationPanel.SetActive(false);
                button.SetActive(true);
            }
        }
    }
}
