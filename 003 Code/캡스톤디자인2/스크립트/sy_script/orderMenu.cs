using UnityEngine;
using TMPro; 
using System.IO; 

public class OrderMenu : MonoBehaviour
{
    public TMP_Text displayText;
    public string orderSaveFileName = "orderMenuData.json";

    private OrderMenuData loadedOrderData;

    void Start()
    {
        LoadDataFromFile();
        if (loadedOrderData != null)
        {DisplayOrderData();}
    }

    private void LoadDataFromFile()
    {
        string loadPath = Path.Combine(Application.persistentDataPath, orderSaveFileName);
        if (File.Exists(loadPath))
        {
            string jsonData = File.ReadAllText(loadPath);
            loadedOrderData = JsonUtility.FromJson<OrderMenuData>(jsonData);
        }
    }

    private void DisplayOrderData()
    {
        if (loadedOrderData != null)
        {
            string displayString = loadedOrderData.menuName + "\n"
                                   + loadedOrderData.count + "\n"
                                   + string.Join(", ", loadedOrderData.options);
            displayText.text = displayString; 
        }
    }
}

