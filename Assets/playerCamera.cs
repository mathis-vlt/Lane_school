using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, -90f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -20f, 20f);

        transform.localRotation = Quaternion.Euler(yRotation, - xRotation -90, 0f);


        if(Input.GetKey(KeyCode.C))
        {
            transform.localRotation = Quaternion.Euler(yRotation, 90, 0f);
        }
    }
}
