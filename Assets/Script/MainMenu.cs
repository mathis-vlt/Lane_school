using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public UIButton[] MenuButton;
    public UIButton OptionsButton;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuButton[0].click)
        {
            SceneManager.LoadScene("Maxime");
        }
        if (MenuButton[1].click)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            optionsMenu.SetActive(!optionsMenu.activeSelf);
            MenuButton[1].click = false;
        }
        if (MenuButton[2].click)
        {
            Debug.Log("Vous avez quitté");
            Application.Quit();
        }

        if (OptionsButton.click)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            optionsMenu.SetActive(!optionsMenu.activeSelf);
            OptionsButton.click = false;
        }
    }
}
