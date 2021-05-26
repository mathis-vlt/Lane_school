using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public PlayableDirector clip;



    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jouer()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        clip.Play();
    }
    public void Options()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
    public void Retour()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
    public void Quitter()
    {
        Debug.Log("Bonjour");
        Application.Quit();
    }
}
