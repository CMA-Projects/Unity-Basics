using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public KeyCode sprintKey = KeyCode.LeftShift;
    private Rigidbody rb;
    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform; // Get the main camera's transform
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Check if the player is sprinting
        float speed = Input.GetKey(sprintKey) ? sprintSpeed : walkSpeed;

        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get the forward and right directions relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalize vectors to avoid diagonal speed boost and ignore y-component
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction based on camera orientation
        Vector3 movement = (forward * moveVertical + right * moveHorizontal) * speed;

        // Apply the movement to the Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
