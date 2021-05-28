using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public static bool jeuEnPause = false;
    public GameObject menuPauseUI;
    public Slider sliderVolume;
    public TextMeshProUGUI textVolume;

    // Update is called once per frame
    private void Start()
    {
        if (!PlayerPrefs.HasKey("SoundOptions"))
        {
            PlayerPrefs.SetFloat("SoundOptions", 1f);
        }
        sliderVolume.value = PlayerPrefs.GetFloat("SoundOptions");
        textVolume.text = "Volume : " + (int)(sliderVolume.value * 100) + "%";
    }
    void Update()
    {
        if (sliderVolume.value != PlayerPrefs.GetFloat("SoundOptions"))
        {
            PlayerPrefs.SetFloat("SoundOptions", sliderVolume.value);
            textVolume.text = "Volume : " + (int)(sliderVolume.value * 100) + "%";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jeuEnPause)
            {
                Reprendre();
            }
            else
            {
                Pause();
            }
        }
    }
 
    public void Reprendre()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        jeuEnPause = false;
    }
    void Pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        jeuEnPause = true;
    }
    public void ChargerMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Thomas");
    }
    public void QuitterJeu()
    {
        Debug.Log("Sortie du jeu...");
        Application.Quit();
    }
}
