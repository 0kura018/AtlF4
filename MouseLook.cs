using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] bool canIRotate;
    private float yRotation = 0f;   
    private PlayerMovementController playerMovementController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.Rotate(0, -90, 0);
    }
    private void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation -= mouseY;

            yRotation = Mathf.Clamp(yRotation, 0, 0);

        if (!canIRotate)
            transform.localRotation = Quaternion.Euler(yRotation, 360, 360);
        else
            transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
