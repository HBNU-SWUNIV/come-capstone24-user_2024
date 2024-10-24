using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // 플레이어의 Transform을 참조

    void Update()
    {
        if (player != null)
        {
            // 버튼이 플레이어를 향하도록
            transform.LookAt(player);
            // 회전 보정
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        }
    }
}
