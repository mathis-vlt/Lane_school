using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitterScreamer2 : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Thomas");
    }
}
