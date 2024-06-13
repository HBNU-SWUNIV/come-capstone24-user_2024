using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject targetButton;
    public GameObject narrationPanel;

    public void OnButtonClick()
    {
        if (targetButton != null)
        {
            targetButton.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    public void End_Narration()
    {
        gameObject.SetActive(false);
        narrationPanel.SetActive(true);
    }
}
