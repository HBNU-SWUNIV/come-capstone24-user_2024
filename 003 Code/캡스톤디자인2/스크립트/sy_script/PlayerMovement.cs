using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public float gravityScale = 2f; // 중력 스케일

    private CharacterController controller; // 캐릭터 컨트롤러
    private Vector3 moveDirection; // 이동 방향
    private Camera mainCamera; // 메인 카메라

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing on this GameObject.");
        }

        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * moveZ + right * moveX).normalized * moveSpeed;

        if (controller.isGrounded)
        {
            if (moveDirection.y < 0)
            {moveDirection.y = -2f;}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime; // 중력 적용
        }

        moveDirection.x = desiredMoveDirection.x;
        moveDirection.z = desiredMoveDirection.z;

        // 이동 적용
        controller.Move(moveDirection * Time.deltaTime);
    }
}
