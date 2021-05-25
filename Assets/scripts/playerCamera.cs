using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;
    float smooth = 5.0f;

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
               


        if(Input.GetKey(KeyCode.C))
        {
            Quaternion cible = Quaternion.Euler(mouseX, 90, 0f);
            transform.localRotation = Quaternion.Slerp(transform.rotation, cible, Time.deltaTime * smooth);
        }
        else
        {
            xRotation -= mouseX;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -20f, 20f);

            Quaternion cibleBase = Quaternion.Euler(yRotation, -xRotation - 90, 0f);
            transform.localRotation = Quaternion.Slerp(transform.rotation, cibleBase, Time.deltaTime * smooth);
        }
    }
}
