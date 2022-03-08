using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    Transform camTransform;

    public float mouseSensitivity = 5f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
