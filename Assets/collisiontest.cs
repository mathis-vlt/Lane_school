using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontest : MonoBehaviour
{

    public bool estTriggered;
    playerCamera joueur;

    private void Start()
    {
        estTriggered = false;
        joueur = FindObjectOfType<playerCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube"))
        {
            Debug.Log("blabla");
            estTriggered = true;
            joueur.pointsEleve += 4;
        }
        else
        {
            estTriggered = false;
        }
    }

}
