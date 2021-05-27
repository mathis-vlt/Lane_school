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
    public GameObject[] GoButton;
    public GameObject[] textBases;

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

        GoButton[0].SetActive(true);
        GoButton[1].SetActive(false);
        GoButton[2].SetActive(false);
        GoButton[3].SetActive(false);

        textBases[0].SetActive(false);
        textBases[1].SetActive(false);

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
            GoButton[0].SetActive(!GoButton[0].activeSelf);
            clipBoard.Play();
            StartCoroutine(WaitBoard());
        }
        
    }
    IEnumerator WaitBoard()
    {
        yield return new WaitForSeconds(2);
        GoButton[1].SetActive(!GoButton[1].activeSelf);
        GoButton[2].SetActive(!GoButton[2].activeSelf);
        textBases[0].SetActive(!textBases[0].activeSelf);
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
        GoButton[1].SetActive(!GoButton[1].activeSelf);
        GoButton[2].SetActive(!GoButton[2].activeSelf);
        textBases[0].SetActive(!textBases[0].activeSelf);
        clipBoardRet.Play();
        StartCoroutine(WaitBoardRet());
    }
    IEnumerator WaitBoardRet()
    {
        yield return new WaitForSeconds(2);
        mainMenu.SetActive(!mainMenu.activeSelf);
        GoButton[0].SetActive(!GoButton[0].activeSelf);
    }
    public void Quitter()
    {
        Debug.Log("Bonjour");
        Application.Quit();
    }
    public void Suite()
    {
        GoButton[1].SetActive(!GoButton[1].activeSelf);
        GoButton[2].SetActive(!GoButton[2].activeSelf);
        GoButton[3].SetActive(!GoButton[3].activeSelf);

        textBases[0].SetActive(!textBases[0].activeSelf);
        textBases[1].SetActive(!textBases[1].activeSelf);
    }
    public void BasesRetour()
    {
        GoButton[1].SetActive(!GoButton[1].activeSelf);
        GoButton[2].SetActive(!GoButton[2].activeSelf);
        GoButton[3].SetActive(!GoButton[3].activeSelf);

        textBases[0].SetActive(!textBases[0].activeSelf);
        textBases[1].SetActive(!textBases[1].activeSelf);
    }
}
