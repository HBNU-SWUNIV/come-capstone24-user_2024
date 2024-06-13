using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class first_personCam : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    public GraphicRaycaster raycaster; // Canvas의 GraphicRaycaster 참조
    public EventSystem eventSystem;   // EventSystem 참조

    // Start is called before the first frame update
    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서를 화면 중앙에 고정
    //     // Cursor.visible = false;                    // 마우스 커서 숨김
    // }

    void Update()
    {
        // 좌우 이동량 * 좌우로 회전할 양 (+속도)
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래 이동량 * 회전할 양 계산 (+속도) (하늘, 바닥)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 (각도 제한 -45:하늘방향, 80:바닥방향)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        // UI 버튼 클릭 처리 //test 상황에서 사용 예정
        // if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 감지
        // {
        //     PointerEventData pointerEventData = new PointerEventData(eventSystem);
        //     pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2); // 화면 중앙 좌표

        //     List<RaycastResult> results = new List<RaycastResult>();
        //     raycaster.Raycast(pointerEventData, results);

        //     foreach (RaycastResult result in results)
        //     {
        //         Button button = result.gameObject.GetComponent<Button>();
        //         if (button != null)
        //         {
        //             button.onClick.Invoke();
        //         }
        //     }
        // }
    }
}
