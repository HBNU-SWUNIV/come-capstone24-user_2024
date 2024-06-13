using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // 빌드중에는 로그가 나옴
        #if UNITY_EDITOR
                Debug.Log("게임 종료");
                UnityEditor.EditorApplication.isPlaying = false; // 플레이 상태 변경
        #else
                Application.Quit(); // 실제 게임
        #endif
    }
}
