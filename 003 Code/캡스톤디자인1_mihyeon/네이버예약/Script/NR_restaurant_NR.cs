using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NR_restaurant_NR : MonoBehaviour
{
    public GameObject imagePanel1; // 이미지1이 포함된 패널
    public GameObject imagePanel2; // 이미지2가 포함된 패널
    public GameObject imagePanel3; // 이미지3이 포함된 패널
    public GameObject imagePanel4;
    public GameObject imagePanel5;
    public GameObject imagePanel6;
    public GameObject imagePanel7;
    public GameObject imagePanel8;
    public TextMeshProUGUI narrationText; // 내레이션 텍스트
    private int currentIndex = 0; // 현재 텍스트 인덱스
    public string[] textArray = new string[] {
        "안녕하세요 네이버예약을 하고 싶으신가요? \n마우스 버튼을 클릭해 다음 화면으로 넘겨주세요.",
        "먼저 네이버예약을 하려면 네이버에 로그인을 해야합니다.",
        "아이디가 없으시다면 아래 회원가입을 완료한 다음 다시 진행해주세요.",
        "네이버 검색창에 예약하려는 업체명을 검색하거나 \n근처 미용실, 근처 맛집 등 키워드로 검색합니다.\n 예시: 유성구 맛집",
        "검색결과에서 1(스크롤)을 아래로 내려서 플레이스를 찾습니다. \n예약/예매/주문 버튼이 있다면 해당 버튼을 눌러 진행할 수 있습니다.",
        "1.예약을 마우스로 클릭합니다.\n2. 2번 화면에서 원하는 상품을 클릭해주세요. \n - 방문 인원, 원하는 날짜, 시간, 상품 등의 정보를 선택해주세요.\n 원하는 일정이 없다면 예약이 불가합니다. 매장에 문의해주세요.",
        "1.예약을 마우스로 클릭합니다.\n2. 2번 화면에서 원하는 상품을 클릭해주세요. \n - 방문 인원, 원하는 날짜, 시간, 상품 등의 정보를 선택해주세요.\n 원하는 일정이 없다면 예약이 불가합니다. 매장에 문의해주세요.",
        "예약 내역을 확인하는 방법은 사진에 나온 방법을 따라 \n네이버 MY플레이스 또는 네이버 마이플레이스를 검색 후 접속합니다.",
        " 1. 예약/주문을 누릅니다. \n 2. 예약을 누른 뒤 내역을 확인합니다. \n 3. 예약 내역에서 예약한 상품의 이름 부분을 눌러 상세 내역을 확인합니다. (무통장 입금 계좌번호 등 확인 가능)"
    };

    void Start()
    {
        // 초기 텍스트 표시
        narrationText.text = textArray[0];
        
        // 초기 이미지 패널 비활성화
        imagePanel1.SetActive(false);
        currentIndex = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 시
        {
            // 현재 인덱스가 텍스트 배열의 길이보다 작으면
            if (currentIndex < textArray.Length)
            {
                // 다음 텍스트 표시
                narrationText.text = textArray[currentIndex];
                

                // 이미지 패널 변경

                if (currentIndex == 1)
                {
                    imagePanel1.SetActive(true); // 이미지1 활성화
                    imagePanel2.SetActive(false); // 이미지2 비활성화
                    imagePanel3.SetActive(false); // 이미지3 비활성화
                    imagePanel4.SetActive(false);
                    imagePanel5.SetActive(false);
                    imagePanel6.SetActive(false);
                    imagePanel7.SetActive(false);
                    imagePanel8.SetActive(false);
                }
                else if (currentIndex == 2)
                {
                    imagePanel1.SetActive(false); // 이미지1 활성화
                    imagePanel2.SetActive(true); // 이미지2 비활성화
                }
                else if (currentIndex == 3)
                {
                    imagePanel2.SetActive(false); // 이미지2 비활성화
                    imagePanel3.SetActive(true); // 이미지3 활성화
                }
                else if (currentIndex == 4)
                {
                    imagePanel3.SetActive(false); 
                    imagePanel4.SetActive(true);
                }
                else if (currentIndex == 5)
                {
                    imagePanel4.SetActive(false); 
                    imagePanel5.SetActive(true); 
                }
                else if (currentIndex == 6)
                {
                    imagePanel5.SetActive(false); 
                    imagePanel6.SetActive(true); 
                }
                else if (currentIndex == 7)
                {
                    imagePanel6.SetActive(false); 
                    imagePanel7.SetActive(true); 
                }
                else if (currentIndex == 8)
                {
                    imagePanel7.SetActive(false); 
                    imagePanel8.SetActive(true); 
                }

                // 다음 텍스트 표시
                currentIndex++;

            }
        }
    }
}
