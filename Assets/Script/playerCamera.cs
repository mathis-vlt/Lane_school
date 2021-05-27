using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool usedPc;

    public string texteErreur;

    public GameObject erreurOrdiUsed;

    public bool ordiFaceVisee;

    public float valStress = 0f;

    //public RawImage calque;
    //float couleurCalqueBase = 1;

    Vector2 size = new Vector2(10, 10);


    /*
     Barre de stress :
        Dès que l'on ne regarde pas l'ordinateur de base, la barre de stresse commence a augmenter,
        elle diminue si on regarde notre pc.

        Plus la barre de stress augmente, plus le champs de vision est réduit.

        Quand la barre de stress est au maximum, la barre tremble.
      */

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        barreTriche.SetActive(false);
        erreurOrdiUsed.SetActive(false);

        usedPc = false;

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
        //Debug.Log("face non visée");
        ordiFaceVisee = false;
        chargementStress();

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
            if (hit.transform.name == "ordiFace")
            {
                ordiFaceVisee = true;
            }
            else
            {
                //Debug.Log("face non visée");
                ordiFaceVisee = false;
                chargementStress();
            }

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
            erreurOrdiUsed.SetActive(false);
        }
    }



    void chargementTriche(int indexOrdi)
    {
        verificationOrdiDispo(indexOrdi);
        if (concentration >= 99)
            barreConcentrationChargee = true;
        else if (concentration <= 0)
            barreConcentrationChargee = false;

        //Mattre un if pour vérifier sur le raycast pointe pas déja usr un ordi pendant le chargement de la concentration
        //Debug.Log(barreConcentrationChargee);
        //Debug.Log(concentration);

        if (estVisee && finChargement == false && barreConcentrationChargee && usedPc == false)
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
        //Debug.Log(pointsEleve);
    }

    void verificationOrdiDispo(int indexOrdi)
    {

        
        if (ordisUtilises.Contains(0))
        {
            //Debug.Log("ordi arrière deja utilisé");
        }
        if(ordisUtilises.Contains(1))
        {
            //Debug.Log("ordi gauche deja utilisé");
        }
        if (ordisUtilises.Contains(2))
        {
            //Debug.Log("ordi droit deja utilisé");
        }

        if (ordisUtilises.Contains(indexOrdi))
        {
            usedPc = true;
            texteErreur = " ";
            if (indexOrdi == 0)
                texteErreur = "arrière";
            else if (indexOrdi == 1)
                texteErreur = "gauche";
            else if (indexOrdi == 2)
                texteErreur = "droit";

            erreurOrdiUsed.SetActive(true);
            
        }
        else
        {
            usedPc = false;
            erreurOrdiUsed.SetActive(false);
        }
            

    }

        void chargementStress()
        {
        for (int i = 0; i <= 100; i++)
            {
                valStress = valStress + Time.deltaTime * speed;

                if (valStress > 99)
                    valStress = 100;
            
            
            //calque.rectTransform.sizeDelta = new Vector2(calque.rectTransform.sizeDelta.x - Time.deltaTime * (valStress/100 /3), calque.rectTransform.sizeDelta.y - Time.deltaTime * (valStress /100 / 2));
            scriptStress.instance.UseStress(Time.deltaTime * speed);
            //Debug.Log("val stress = " + valStress);
            }
        
    }
}
