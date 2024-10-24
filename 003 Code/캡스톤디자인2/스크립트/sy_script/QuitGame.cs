using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // 빌드중에는 로그 출력
        #if UNITY_EDITOR
                Debug.Log("게임 종료");
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 실제 빌드된 게임
        #endif
    }
}
