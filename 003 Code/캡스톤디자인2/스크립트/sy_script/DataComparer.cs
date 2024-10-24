using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class DataComparer : MonoBehaviour
{
    public TMP_Text resultText;
    public string menuSaveFileName = "menuSaveData.json";
    public string orderMenuSaveFileName = "orderMenuData.json";

    private MenuSaveData loadedMenuData;
    private OrderMenuData loadedOrderMenuData;
    private List<MenuSaveData> savedDataList;

    public void CompareData()
    {
        LoadMenuData();
        LoadOrderMenuData();

        if (savedDataList != null && savedDataList.Count > 0 && loadedOrderMenuData != null)
        {
            loadedMenuData = savedDataList[0];
            int mismatchCount = CompareMenuAndOrderData(loadedMenuData, loadedOrderMenuData);

            resultText.text = mismatchCount.ToString();
        }
    }

    private void LoadMenuData()
    {
        string loadPath = Path.Combine(Application.persistentDataPath, menuSaveFileName);
        if (File.Exists(loadPath))
        {
            string jsonData = File.ReadAllText(loadPath);
            savedDataList = JsonUtility.FromJson<MenuSaveDataListWrapper>(jsonData).savedDataList;
        }
    }

    private void LoadOrderMenuData()
    {
        string loadPath = Path.Combine(Application.persistentDataPath, orderMenuSaveFileName);
        if (File.Exists(loadPath))
        {
            string jsonData = File.ReadAllText(loadPath);
            loadedOrderMenuData = JsonUtility.FromJson<OrderMenuData>(jsonData);
        }
    }

    private int CompareMenuAndOrderData(MenuSaveData menuData, OrderMenuData orderData)
    {
        int mismatchCount = 0;

        // 메뉴 이름
        if (menuData.menuName != orderData.menuName)
        {
            mismatchCount++;
        }

        if (menuData.count != orderData.count)
        {
            mismatchCount++;
        }

        List<string> menuOptions = menuData.activeToggleTexts ?? new List<string>();
        List<string> orderOptions = orderData.options ?? new List<string>();

        // 옵션 차이
        foreach (string option in menuOptions)
        {
            if (!orderOptions.Contains(option))
            {
                mismatchCount++;
            }
        }

        // 옵션 차이 (orderOptions -> menuOptions)
        /*foreach (string option in orderOptions)
        {
            if (!menuOptions.Contains(option))
            {
                mismatchCount++;
            }
        }*/

        return mismatchCount;
    }
}

[System.Serializable]
public class MenuSaveDataListWrapper
{
    public List<MenuSaveData> savedDataList;
}
