using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;
    float xRotationMaxEtMin = 55f;
    float yRotationMaxEtMin = 20f;
    float smooth = 3.0f;
    float range = 100f;

    public int pointsEleve = 0;

    public float Chargement = 0f;
    bool finChargement;
    bool estVisee;


    public GameObject barreTriche;
    private float speed = 0.2f;

    public float concentration = 100f;

    bool barreConcentrationChargee;

    private List<int> ordisUtilises = new List<int>();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        barreTriche.SetActive(false);


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

        if (!estVisee)
        {
            Chargement = 0;
            barreTriche.Equals(0);
        }
            
        
    }


    void tricheArriere()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            estVisee = true;
            if(hit.transform.name == "ordiTriche")
            {
                
                estVisee = true;                
                chargementTriche(0);

            }
        }else
        {
            resetBarreTriche();
            estVisee = false;
            finChargement = false;
        }
    }


    void tricheCote()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            estVisee = true;
            if (hit.transform.name == "ordiGauche")
            {               
                estVisee = true;
                chargementTriche(1);

            }

            if (hit.transform.name == "ordiDroit")
            {
                
                estVisee = true;
                chargementTriche(2);
            }
        }
        else
        {
            resetBarreTriche();
            estVisee = false;
            finChargement = false;
        }
    }



    void chargementTriche(int indexOrdi)
    {

        verificationOrdiDispo();
        if (concentration >= 99)
            barreConcentrationChargee = true;
        else if (concentration <= 0)
            barreConcentrationChargee = false;

        //Mattre un if pour vérifier sur le raycast pointe pas déja usr un ordi pendant le chargement de la concentration
        //Debug.Log(barreConcentrationChargee);
        //Debug.Log(concentration);

        if (estVisee && finChargement == false  && barreConcentrationChargee)
        {
            barreTriche.SetActive(true);
            for (int i = 0; i <= 100; i++)
            {
                Chargement = Chargement + Time.deltaTime * speed;
                concentration = concentration - Time.deltaTime * speed;
                
                if (Chargement > 99)
                    Chargement = 100;

                scriptConcentration.instance.UseConcentration(Time.deltaTime * speed);
                //Debug.Log(Chargement);
                if (Chargement >= 100)
                {
                    resetBarreTriche();
                    finChargement = true;
                    pointsEleve = pointsEleve + 1;
                    ordisUtilises.Add(indexOrdi);
                    
                }
            }
        }
    }

    void resetBarreTriche()
    {
        Chargement = 0;
        barreTriche.SetActive(false);
        Debug.Log(pointsEleve);
    }

    void verificationOrdiDispo()
    {   
        if(ordisUtilises.Contains(0))
        {
            Debug.Log("ordi arrière deja utilisé");
        }
    }

}
