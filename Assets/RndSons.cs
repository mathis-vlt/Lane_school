using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndSons : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource laSource;
    public AudioClip[] listeClip;
    private int rnd ;

    void Awake()
    {
        laSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        rnd = Random.Range(0, listeClip.Length);
        laSource.clip = listeClip[rnd];
        laSource.PlayOneShot(laSource.clip);
    }
    void Update()
    {
        if (!laSource.isPlaying)
        {
            rnd = Random.Range(0, listeClip.Length);
            laSource.clip = listeClip[rnd];
            laSource.PlayOneShot(laSource.clip);
        }
    }
}
