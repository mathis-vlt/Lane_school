using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;
    public float xRotationMaxEtMin = 50f;
    public float yRotationMaxEtMin = 20f;
    float smooth = 3.0f;
    float range = 100f;

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
        


        if (Input.GetKey(KeyCode.C))
        {
            Quaternion cible = Quaternion.Euler(0f, 90f, 0f);   
            transform.localRotation = Quaternion.Slerp(transform.rotation, cible, Time.deltaTime * smooth);
            tricheArriere();
        }
        else
        {
            xRotation -= mouseX;
            xRotation = Mathf.Clamp(xRotation, -xRotationMaxEtMin, xRotationMaxEtMin);

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -yRotationMaxEtMin, yRotationMaxEtMin);

            Quaternion cibleBase = Quaternion.Euler(yRotation, -xRotation - 90, 0f);
            transform.localRotation = Quaternion.Slerp(transform.rotation, cibleBase, Time.deltaTime * smooth);
            tricheCote();
        }


        
    }


    void tricheArriere()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.name == "ordiTriche")
            {
                Debug.Log("Lancer triche arrière");
            }
        }        
    }


    void tricheCote()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.name == "ordiGauche")
            {
                Debug.Log("Lancer triche gauche");
            }

            if (hit.transform.name == "ordiDroit")
            {
                Debug.Log("Lancer triche droit");
            }
        }
    }
}
