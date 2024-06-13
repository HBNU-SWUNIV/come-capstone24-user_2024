using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nr_imageChange_buttin : MonoBehaviour
{
    public GameObject targetImage;
    public GameObject currentImage;

    public void OnButtonClick()
    {
        if (targetImage != null)
        {
            targetImage.SetActive(true);
        }
        if (currentImage != null)
        {
            currentImage.SetActive(false);
        }
    }
}
