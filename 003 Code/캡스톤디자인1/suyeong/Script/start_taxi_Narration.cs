using UnityEngine;
using TMPro; 

public class start_taxi_Narration : MonoBehaviour
{
    public TextMeshProUGUI narrationText;
    public GameObject narrationPanel;
    private int currentIndex = 0;
    public GameObject button;
    public string[] textArray = new string[] {
        "Let's follow me and find out how to use Kakao Taxi",
        "Let's take up the phone and run the app??"
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
