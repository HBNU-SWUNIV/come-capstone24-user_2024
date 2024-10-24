using UnityEngine;

public class Delay_ob : MonoBehaviour
{
    public GameObject targetObject;  
    public float delayTime = 2.0f;   // 딜레이
    public bool activate = true;    

    public void OnButtonClick()
    {
        Invoke("ActivateObject", delayTime);
    }

    void ActivateObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(activate);
        }
    }
}
