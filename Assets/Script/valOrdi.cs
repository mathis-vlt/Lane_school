using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class valOrdi : MonoBehaviour
{
    TMP_Text texteOrdi;
    public playerCamera joueur;
    
    void Start()
    {
        texteOrdi = GetComponent<TMP_Text>();
        joueur = FindObjectOfType<playerCamera>();
    }

    

    void Update()
    {
        string textNote = "L'ordinateur " + joueur.texteErreur + " a déjè été utilisé";
        texteOrdi.text = textNote;
    }

}
