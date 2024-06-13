using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoader: MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject nextCanvas;

    public void LoadCanvas()
    {
        if (currentCanvas != null && nextCanvas != null)
        {
            currentCanvas.SetActive(false);
            nextCanvas.SetActive(true);
        }
    }
}
