using UnityEngine;
using UnityEngine.UI;  
using TMPro;  
using System.Collections.Generic;  
using System.IO;  

[System.Serializable]
public class MenuSaveData
{
    public string menuName;    // 메뉴 이름
    public int price;          // 메뉴 가격
    public int count;          // 메뉴 갯수
    public List<string> activeToggleTexts;
}

public class MenuStateSaver : MonoBehaviour
{
    public TMP_Text menuNameText;  // 메뉴 이름
    public TMP_Text priceText;     // 가격
    public TMP_Text countText;     // 갯수
    public List<Toggle> toggles;   // 토글
    public string saveFileName = "menuSaveData.json";

    public List<MenuSaveData> savedDataList = new List<MenuSaveData>();

    public void OnConfirmButtonClick()
    {
        MenuSaveData newSaveData = new MenuSaveData();

        newSaveData.menuName = menuNameText.text;
        newSaveData.price = int.Parse(priceText.text);
        newSaveData.count = int.Parse(countText.text);

        newSaveData.activeToggleTexts = new List<string>();
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                TMP_Text toggleText = toggle.GetComponentInChildren<TMP_Text>();
                if (toggleText != null)
                {
                    newSaveData.activeToggleTexts.Add(toggleText.text);
                }
            }
        }

        savedDataList.Clear();  // 기존 리스트를 비움
        savedDataList.Add(newSaveData);
        SaveDataToFile();
    }

    private void SaveDataToFile()
    {
        string savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        string jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(savePath, jsonData);
    }

    public void LoadDataFromFile()
    {
        string loadPath = Path.Combine(Application.persistentDataPath, saveFileName);
        if (File.Exists(loadPath))
        {
            string jsonData = File.ReadAllText(loadPath);
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
    }
}
