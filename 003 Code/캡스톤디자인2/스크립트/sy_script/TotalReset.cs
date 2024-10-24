using UnityEngine;
using System.IO;

public class TotalReset : MonoBehaviour
{
    public string saveFileName = "menuSaveData.json";

    public void ResetDataAndDeleteFile()
    {
        string savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
