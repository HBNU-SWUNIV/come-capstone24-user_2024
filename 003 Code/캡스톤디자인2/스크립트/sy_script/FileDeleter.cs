using UnityEngine;
using System.IO;  

public class FileDeleter : MonoBehaviour
{
    public string menuSaveFileName = "menuSaveData.json";  
    public string orderSaveFileName = "orderMenuData.json";  
    public void OnDeleteButtonClick()
    {
        DeleteFile(menuSaveFileName);  
        DeleteFile(orderSaveFileName); 
    }

    private void DeleteFile(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
