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
    public GameObject[] button;

    public UIButton bases;
    
    public PlayableDirector clipJouer;
    public PlayableDirector clipOptions;
    public PlayableDirector clipRetour;
    public PlayableDirector clipBoard;
    public PlayableDirector clipBoardRet;

    public TextMeshProUGUI textVolume;

    public Slider sliderVolume;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        button[1].SetActive(false);
        button[0].SetActive(true);
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
        if (bases.click)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            bases.click = false;
            button[0].SetActive(!button[0].activeSelf);
            clipBoard.Play();
            StartCoroutine(WaitBoard());
        }
    }
    IEnumerator WaitBoard()
    {
        yield return new WaitForSeconds(2);
        button[1].SetActive(!button[1].activeSelf);
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
        yield return new WaitForSeconds(2);
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
    public void Board()
    {
        button[1].SetActive(!button[1].activeSelf);
        clipBoardRet.Play();
        StartCoroutine(WaitBoardRet());
    }
    IEnumerator WaitBoardRet()
    {
        yield return new WaitForSeconds(2);
        mainMenu.SetActive(!mainMenu.activeSelf);
        button[0].SetActive(!button[0].activeSelf);
    }
    public void Quitter()
    {
        Debug.Log("Bonjour");
        Application.Quit();
    }
}
