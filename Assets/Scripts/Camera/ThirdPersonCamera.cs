using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;     // The target to follow
    public Vector3 offset = new Vector3(0f, 2f, -5f);   // Camera offset from the target
    public float rotationSpeed = 5f;    // Speed at which the camera rotates

    private void LateUpdate()
    {
        try
        {
            // Calculate the desired position of the camera based on the target and offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);

            // Calculate the desired rotation of the camera to look at the target
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);

            // Smoothly rotate the camera towards the desired rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        } catch
        {
            Debug.LogError("MainCamera: No Target");
        }
    }
}