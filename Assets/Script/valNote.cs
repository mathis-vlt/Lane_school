using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valNote : MonoBehaviour
{
    public Text texte;
    public playerCamera joueur;

    void Start()
    {
        texte = GetComponent<Text>();
        joueur = FindObjectOfType<playerCamera>();
    }

    
    void Update()
    {
        string textNote = "Note : " + joueur.pointsEleve + "/10";
        texte.text = textNote;
    }
}
