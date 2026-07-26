using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private Vector3 moveDirection;

    private bool sprinting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirection = new Vector3(h, 0, v);

        if (moveDirection.magnitude > 1f)
            moveDirection.Normalize();

        float speed = sprinting ? sprintSpeed : moveSpeed;

        controller.Move(moveDirection * speed * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rot,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    public void StartSprint()
    {
        sprinting = true;
    }

    public void StopSprint()
    {
        sprinting = false;
    }
}
