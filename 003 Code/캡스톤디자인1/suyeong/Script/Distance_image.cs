using UnityEngine;
using UnityEngine.UI;

public class Distance_image: MonoBehaviour
{
    public GameObject player; // 플레이어
    public GameObject targetObject;

    public Image targetImage;
    public float activationDistance = 5.0f; // 이미지 거리

    public MonoBehaviour targetScript1;
    public MonoBehaviour targetScript2;

    void Start()
    {
        if (targetImage != null)
        {targetImage.gameObject.SetActive(false);}
    }

    void Update()
    {
        if (targetObject != null && targetObject.activeInHierarchy)
        {
            float distance = Vector3.Distance(player.transform.position, targetObject.transform.position);

            if (distance <= activationDistance)
            {
                if (targetImage != null)
                {
                    targetImage.gameObject.SetActive(true);
                    targetScript1.enabled = false;
                    targetScript2.enabled = false;
                }
            }
            else
            {
                if (targetImage != null)
                {targetImage.gameObject.SetActive(false);}
            }
        }
    }
}
