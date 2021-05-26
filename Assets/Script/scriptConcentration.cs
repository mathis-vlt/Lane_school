using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptConcentration : MonoBehaviour
{
    public Slider barreConcentration;

    private int maxConcentration = 100;
    private int minConcentration = 0;
    playerCamera joueur;
    public float actuelConcentration;

    private WaitForSeconds regenTicks = new WaitForSeconds(0.05f);
    private Coroutine regen;

    public static scriptConcentration instance;



    public void Awake()
    {
        instance = this;
    }
    




    void Start()
    {
        joueur = FindObjectOfType<playerCamera>();
        actuelConcentration = maxConcentration;
        barreConcentration.maxValue = maxConcentration;
        barreConcentration.minValue = minConcentration;
        barreConcentration.value = maxConcentration;
    }





    public void UseConcentration(float total)
    {
        if(actuelConcentration - total >= 0)
        {
            actuelConcentration -= total;
            barreConcentration.value = actuelConcentration;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenConcentration());
        }
        else
        {
            Debug.Log("pas assez de concentration");
        }
    }

    private IEnumerator RegenConcentration()
    {
        yield return new WaitForSeconds(3);

        while(actuelConcentration < maxConcentration)   
        {            
            actuelConcentration += maxConcentration / 100;
            joueur.concentration ++;
            barreConcentration.value = actuelConcentration;
            yield return regenTicks;
            Debug.Log("recharge");
        }
        
        regen = null;

    }
}
