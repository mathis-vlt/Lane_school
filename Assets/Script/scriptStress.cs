using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptStress : MonoBehaviour
{
    public Slider sliderStress;

    private int maxStress = 100;
    private int minStress = 0;
    playerCamera joueur;
    public float actuelStress;

    private WaitForSeconds regenTicks = new WaitForSeconds(0.05f);
    private Coroutine regenStress;

    public static scriptStress instance;

    public RawImage calque;

    float speed = 0.1f;

    float opacite = 0f;


    

    public void Awake()
    {
        instance = this;
    }


    public void Start()
    {
        joueur = FindObjectOfType<playerCamera>();
        actuelStress = minStress;
        sliderStress.maxValue = maxStress;
        sliderStress.minValue = minStress;
        sliderStress.value = minStress;
        opacite = 0;
    }

    public void Update()
    {
        opacite = sliderStress.value / 100;
        if (opacite > 1)
            opacite = 1f;

        calque.color = new Color(255, 255, 255, opacite);

    }



    public void UseStress(float total)
    {
        if (!joueur.ordiFaceVisee)
        {
                        
            actuelStress += total;
            sliderStress.value = actuelStress;

           
           

            

            if (actuelStress > 100)
                actuelStress = 100f;

            if (regenStress != null)
                StopCoroutine(regenStress);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                
                if (hit.transform.name == "ordiFace")
                {
                    joueur.ordiFaceVisee = true;
                    
                }
                else
                {
                    joueur.ordiFaceVisee = false;
                }
            }

            if (!joueur.ordiFaceVisee)
            {
                regenStress = StartCoroutine(RegenStress());
            }
            
        }

        
    }

    private IEnumerator RegenStress()
    {
        yield return new WaitForSeconds(0);
        //Debug.Log("entrée fonction");
        while (actuelStress > minStress)
        {
            actuelStress -= maxStress / 100;
            joueur.valStress--;
            sliderStress.value = actuelStress;
            opacite = sliderStress.value / 100;
            yield return regenTicks;
            //Debug.Log(joueur.valStress);
            
        }
        regenStress = null;
        
    }

}
