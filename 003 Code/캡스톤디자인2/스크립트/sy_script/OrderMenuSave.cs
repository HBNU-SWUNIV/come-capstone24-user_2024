using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

[System.Serializable]
public class OrderMenuData
{
    public string menuName;
    public int count;
    public List<string> options;
}

public class OrderMenuSave : MonoBehaviour
{
    public string saveFileName = "orderMenuData.json";
    private List<string> coffeeOptions = new List<string> { "HOT", "ICE", "샷 추가", "휘핑크림 추가" };
    private List<string> teaOptions = new List<string> { "HOT", "ICE" };
    private List<string> dessertOptions = new List<string> { "휘핑크림 추가", "초코소스 추가" };
    private List<string> toastOptions = new List<string> { "치즈 추가", "야채 추가", "햄 추가" };

    private Dictionary<string, List<string>> menuDictionary = new Dictionary<string, List<string>>()
    {
        { "coffee", new List<string> { "아메리카노", "카페라떼", "에스프레소" } },
        { "tea", new List<string> { "홍차", "얼그레이티" } },
        { "dessert", new List<string> { "크루아상", "우유도넛", "딸기도넛", "초코도넛", "쿠키머핀", "딸기머핀", "오레오머핀" } },
        { "toast", new List<string> { "기본토스트", "올리브토스트", "피자토스트", "오렌지샌드", "딸기샌드", "참깨토스트" } },
        { "other", new List<string> { "오렌지주스", "초코칩쿠키", "마카롱(6p)", "블루베리케이크", "초코케이크", "딸기케이크" } }
    };

    public void OnConfirmOrderClick()
    {
        //카테고리
        string randomCategory = GetRandomCategory();
        List<string> selectedMenu = menuDictionary[randomCategory];

        //메뉴
        string randomMenu = selectedMenu[UnityEngine.Random.Range(0, selectedMenu.Count)];

        //수량
        int randomcount = UnityEngine.Random.Range(1, 6);

        //옵션
        List<string> selectedOptions = GetRandomOptions(randomCategory);

        OrderMenuData newOrderData = new OrderMenuData
        {
            menuName = randomMenu,
            count = randomcount,
            options = selectedOptions
        };

        SaveDataToFile(newOrderData);
    }

    private string GetRandomCategory()
    {
        List<string> categories = new List<string>(menuDictionary.Keys);
        return categories[UnityEngine.Random.Range(0, categories.Count)];
    }

    private List<string> GetRandomOptions(string category)
    {
        List<string> availableOptions = new List<string>();
        if (category == "coffee" || category == "tea")
        {
            // HOT 또는 ICE는 필수
            availableOptions = category == "coffee" ? coffeeOptions : teaOptions;

            string hotOrIce = availableOptions[UnityEngine.Random.Range(0, 2)];
            availableOptions.RemoveAt(0);
            availableOptions.RemoveAt(0);

            List<string> selectedOptions = new List<string> { hotOrIce };

            int optionCount = UnityEngine.Random.Range(0, 3);
            for (int i = 0; i < optionCount; i++)
            {
                string randomOption = availableOptions[UnityEngine.Random.Range(0, availableOptions.Count)];
                if (!selectedOptions.Contains(randomOption))
                {selectedOptions.Add(randomOption);}
            }
            return selectedOptions;
        }
        else
        {
            if (category == "dessert") availableOptions = dessertOptions;
            else if (category == "toast") availableOptions = toastOptions;

            List<string> selectedOptions = new List<string>();

            int optionCount = UnityEngine.Random.Range(0, 3);
            for (int i = 0; i < optionCount; i++)
            {
                string randomOption = availableOptions[UnityEngine.Random.Range(0, availableOptions.Count)];
                if (!selectedOptions.Contains(randomOption))
                {
                    selectedOptions.Add(randomOption);
                }
            }

            return selectedOptions;
        }
    }

    private void SaveDataToFile(OrderMenuData data)
    {
        string savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, jsonData); 
    }
}
