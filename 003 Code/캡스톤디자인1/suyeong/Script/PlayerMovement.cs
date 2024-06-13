using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravityScale = 2f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Camera mainCamera;
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

        // Y축 방향 제거
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // 이동 방향 계산
        Vector3 desiredMoveDirection = (forward * moveZ + right * moveX).normalized * moveSpeed;

        // 중력
        if (controller.isGrounded)
        {
            if (moveDirection.y < 0)
            {
                moveDirection.y = -2f; // 약간의 하강 속도
            }

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
