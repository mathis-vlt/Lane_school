using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool jeuEnPause = false;
    public GameObject menuPauseUI;


    // Update is called once per frame
    void Update()
    {
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
