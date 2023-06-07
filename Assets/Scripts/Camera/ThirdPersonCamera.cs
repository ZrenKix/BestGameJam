using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;                 // The target to follow
    public Vector3 offset = new Vector3(0f, 2f, -5f);   // Camera offset from the target
    public float rotationSpeed = 5f;         // Speed at which the camera rotates
    public float maxVerticalAngle = 60f;     // Maximum vertical rotation angle of the camera

    private float currentX = 0f;             // Current X rotation of the camera
    private float currentY = 0f;             // Current Y rotation of the camera

    private void LateUpdate()
    {
        try
        {
            // Check if touchpad input is used for camera rotation
            bool isTouchpadInputUsed = Input.touchSupported && Input.touchCount > 0;

            // Update camera rotation based on touchpad input
            if (isTouchpadInputUsed)
            {
                Touch touch = Input.GetTouch(0);

                // Check if touch phase is moved or stationary
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    currentX += touch.deltaPosition.x * rotationSpeed;
                    currentY -= touch.deltaPosition.y * rotationSpeed;
                }
            }

            // Clamp vertical camera rotation within the specified range
            currentY = Mathf.Clamp(currentY, -maxVerticalAngle, maxVerticalAngle);

            // Calculate the desired rotation of the camera
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);

            // Calculate the desired position of the camera based on the target, rotation, and offset
            Vector3 desiredPosition = target.position - (rotation * Vector3.forward * offset.z);

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);

            // Smoothly rotate the camera towards the desired rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        catch
        {
            Debug.LogError("MainCamera: No Target");
        }
    }
}