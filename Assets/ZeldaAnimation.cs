using UnityEngine;

public class ZeldaAnimation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float jumpHeight = 1f;
    public float jumpSpeed = 2f;
    private bool isJumping = false;
    private Vector3 initialPosition;
    private int rotationCount = 0;
    private int rotationCounter = 0;
    private bool isRotating = true;
    private float totalRotationAngle = 0f;
    ZeldaAnimation zeldaAnimation;

    private ParticleSystem love;

    private void Start()
    {
        love = GetComponentInChildren<ParticleSystem>();
        zeldaAnimation = GetComponent<ZeldaAnimation>();
        zeldaAnimation.enabled = false;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (rotationCount < 2)
        {
            if (isRotating)
            {
                float rotationAmount = rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);
                totalRotationAngle += rotationAmount;

                if (totalRotationAngle >= 720f)
                {
                    isRotating = false;
                    gameObject.GetComponent<ZeldaAnimation>().enabled = false;
                    love.Play();
                }
            }

            if (!isJumping)
            {
                StartCoroutine(PerformMiniJump());
            }
        }
        else
        {
            isRotating = false;
            isJumping = true;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private System.Collections.IEnumerator PerformMiniJump()
    {
        isJumping = true;

        Vector3 targetPosition = initialPosition + Vector3.up * jumpHeight;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, jumpSpeed * Time.deltaTime);
            yield return null;
        }

        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, jumpSpeed * Time.deltaTime);
            yield return null;
        }

        isJumping = false;

        rotationCount++;

        if (rotationCount >= 2)
        {
            rotationCount = 0;
        }
    }
}