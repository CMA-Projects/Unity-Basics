using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public float verticalRotationLimit = 80f; // Limits how much the camera can tilt up and down

    private float xRotation = 0f; // Track the camera's vertical rotation

    void Start()
    {
        // Lock the cursor to the game window and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply rotation to the camera based on mouse input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);
        
        // Rotate the player horizontally based on mouse movement
        player.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (up and down)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Update the camera's position to follow the player
        transform.position = player.position + player.TransformDirection(offset);

        // Align the camera's rotation with the player's rotation (but keep the vertical rotation)
        transform.rotation = Quaternion.Euler(xRotation, player.eulerAngles.y, 0f);
    }
}
