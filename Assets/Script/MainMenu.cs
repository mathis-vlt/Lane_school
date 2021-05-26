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
    
    public PlayableDirector clipJouer;
    public PlayableDirector clipOptions;
    public PlayableDirector clipRetour;

    public TextMeshProUGUI textVolume;

    public Slider sliderVolume;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        if (!PlayerPrefs.HasKey("SoundOptions"))
        {
            PlayerPrefs.SetFloat("SoundOptions", 1f);
        }
        sliderVolume.value = PlayerPrefs.GetFloat("SoundOptions");
        textVolume.text = "Volume : " + (int)(sliderVolume.value * 100) + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderVolume.value != PlayerPrefs.GetFloat("SoundOptions"))
        {
            PlayerPrefs.SetFloat("SoundOptions", sliderVolume.value);
            textVolume.text = "Volume : " + (int)(sliderVolume.value * 100) + "%";
        }
    }

    public void Jouer()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        clipJouer.Play();
        StartCoroutine(WaitJouer());
    }
    IEnumerator WaitJouer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Maxime");
    }
    public void Options()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        clipOptions.Play();
        StartCoroutine(WaitOptions());
    }
    IEnumerator WaitOptions()
    {
        yield return new WaitForSeconds(2);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
    public void Retour()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        clipRetour.Play();
        StartCoroutine(WaitRetour());
    }
    IEnumerator WaitRetour()
    {
        yield return new WaitForSeconds((float)1.7);
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
    public void Quitter()
    {
        Debug.Log("Bonjour");
        Application.Quit();
    }
}
