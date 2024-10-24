using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_control : MonoBehaviour
{
    public GameObject Panel;  
    public bool isPanelOn;  // on/off 상태

    // 버튼 클릭 시 호출될 메소드
    public void ApplyPanelState()
    {
        if (Panel != null)
        {
            Panel.gameObject.SetActive(isPanelOn);
        }
    }
}
