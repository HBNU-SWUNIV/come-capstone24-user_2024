using UnityEngine;

public class ScriptControl : MonoBehaviour
{
    public GameObject targetObject;  // 조작할 오브젝트
    public MonoBehaviour targetScript;  // 조작할 스크립트
    public bool isScriptOn;  // 스크립트의 on/off 상태

    // 버튼 클릭 시 호출될 메소드
    public void ApplyScriptState()
    {
        if (targetObject != null && targetScript != null)
        {
            targetScript.enabled = isScriptOn;
            Debug.Log("Script " + targetScript.GetType().Name + " on " + targetObject.name + " is now " + (isScriptOn ? "enabled" : "disabled"));
        }
        else
        {
            Debug.LogError("Target object or script is not assigned.");
        }
    }
}

