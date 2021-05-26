using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDéplacement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(0.0F, 100.0F)] private float vitesse;
    [SerializeField] private int tps;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * vitesse);
    }
}
