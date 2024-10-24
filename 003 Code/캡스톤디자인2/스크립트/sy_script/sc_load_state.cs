using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_load_state : MonoBehaviour
{
    public string sceneName;
    public string canvasName;  // 전환할 캔버스 이름

    public void LoadSceneWithCanvas()
    {
        PlayerPrefs.SetString("CanvasName", canvasName);
        SceneManager.LoadScene(sceneName);
    }
}
