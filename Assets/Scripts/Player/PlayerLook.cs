using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private Transform weaponParent;
    [SerializeField] private float xRotation = 0f;

    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void HandleLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        fpsCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        weaponParent.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
