using UnityEngine;

public class Delay_scpt : MonoBehaviour
{
    public MonoBehaviour targetScript; 
    public float delayTime = 2.0f;      
    public bool activate = true;        

    public void OnButtonClick()
    {
        Invoke("ActivateScript", delayTime);
    }

    void ActivateScript()
    {
        if (targetScript != null)
        {targetScript.enabled = activate;}
    }
}
