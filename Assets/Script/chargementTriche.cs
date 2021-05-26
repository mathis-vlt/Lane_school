using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargementTriche : MonoBehaviour
{
    private Image chargementTricheImage;
    public float valChargementTriche;
    private float maxChargement = 100f;
    playerCamera joueur;
    

    // Start is called before the first frame update
    void Start()
    {
        chargementTricheImage = GetComponent<Image>();
        joueur = FindObjectOfType<playerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        valChargementTriche = joueur.Chargement;
        chargementTricheImage.fillAmount = valChargementTriche / maxChargement;
    }
}
