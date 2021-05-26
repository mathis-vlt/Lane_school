using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitterScreamer : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Thomas");
    }
}
