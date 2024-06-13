using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NR_restaurant_NR : MonoBehaviour
{
    public GameObject imagePanel1; // �̹���1�� ���Ե� �г�
    public GameObject imagePanel2; // �̹���2�� ���Ե� �г�
    public GameObject imagePanel3; // �̹���3�� ���Ե� �г�
    public GameObject imagePanel4;
    public GameObject imagePanel5;
    public GameObject imagePanel6;
    public GameObject imagePanel7;
    public GameObject imagePanel8;
    public TextMeshProUGUI narrationText; // �����̼� �ؽ�Ʈ
    private int currentIndex = 0; // ���� �ؽ�Ʈ �ε���
    public string[] textArray = new string[] {
        "�ȳ��ϼ��� ���̹������� �ϰ� �����Ű���? \n���콺 ��ư�� Ŭ���� ���� ȭ������ �Ѱ��ּ���.",
        "���� ���̹������� �Ϸ��� ���̹��� �α����� �ؾ��մϴ�.",
        "���̵� �����ôٸ� �Ʒ� ȸ�������� �Ϸ��� ���� �ٽ� �������ּ���.",
        "���̹� �˻�â�� �����Ϸ��� ��ü���� �˻��ϰų� \n��ó �̿��, ��ó ���� �� Ű����� �˻��մϴ�.\n ����: ������ ����",
        "�˻�������� 1(��ũ��)�� �Ʒ��� ������ �÷��̽��� ã���ϴ�. \n����/����/�ֹ� ��ư�� �ִٸ� �ش� ��ư�� ���� ������ �� �ֽ��ϴ�.",
        "1.������ ���콺�� Ŭ���մϴ�.\n2. 2�� ȭ�鿡�� ���ϴ� ��ǰ�� Ŭ�����ּ���. \n - �湮 �ο�, ���ϴ� ��¥, �ð�, ��ǰ ���� ������ �������ּ���.\n ���ϴ� ������ ���ٸ� ������ �Ұ��մϴ�. ���忡 �������ּ���.",
        "1.������ ���콺�� Ŭ���մϴ�.\n2. 2�� ȭ�鿡�� ���ϴ� ��ǰ�� Ŭ�����ּ���. \n - �湮 �ο�, ���ϴ� ��¥, �ð�, ��ǰ ���� ������ �������ּ���.\n ���ϴ� ������ ���ٸ� ������ �Ұ��մϴ�. ���忡 �������ּ���.",
        "���� ������ Ȯ���ϴ� ����� ������ ���� ����� ���� \n���̹� MY�÷��̽� �Ǵ� ���̹� �����÷��̽��� �˻� �� �����մϴ�.",
        " 1. ����/�ֹ��� �����ϴ�. \n 2. ������ ���� �� ������ Ȯ���մϴ�. \n 3. ���� �������� ������ ��ǰ�� �̸� �κ��� ���� �� ������ Ȯ���մϴ�. (������ �Ա� ���¹�ȣ �� Ȯ�� ����)"
    };

    void Start()
    {
        // �ʱ� �ؽ�Ʈ ǥ��
        narrationText.text = textArray[0];
        
        // �ʱ� �̹��� �г� ��Ȱ��ȭ
        imagePanel1.SetActive(false);
        currentIndex = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ��
        {
            // ���� �ε����� �ؽ�Ʈ �迭�� ���̺��� ������
            if (currentIndex < textArray.Length)
            {
                // ���� �ؽ�Ʈ ǥ��
                narrationText.text = textArray[currentIndex];
                

                // �̹��� �г� ����

                if (currentIndex == 1)
                {
                    imagePanel1.SetActive(true); // �̹���1 Ȱ��ȭ
                    imagePanel2.SetActive(false); // �̹���2 ��Ȱ��ȭ
                    imagePanel3.SetActive(false); // �̹���3 ��Ȱ��ȭ
                    imagePanel4.SetActive(false);
                    imagePanel5.SetActive(false);
                    imagePanel6.SetActive(false);
                    imagePanel7.SetActive(false);
                    imagePanel8.SetActive(false);
                }
                else if (currentIndex == 2)
                {
                    imagePanel1.SetActive(false); // �̹���1 Ȱ��ȭ
                    imagePanel2.SetActive(true); // �̹���2 ��Ȱ��ȭ
                }
                else if (currentIndex == 3)
                {
                    imagePanel2.SetActive(false); // �̹���2 ��Ȱ��ȭ
                    imagePanel3.SetActive(true); // �̹���3 Ȱ��ȭ
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

                // ���� �ؽ�Ʈ ǥ��
                currentIndex++;

            }
        }
    }
}
