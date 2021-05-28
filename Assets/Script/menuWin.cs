using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuWin : MonoBehaviour
{
    public void QuitterMenuWin()
    {
        SceneManager.LoadScene("Thomas");
    }

    public void RejouerMenuWin()
    {
        SceneManager.LoadScene("Maxime");
    }
}
