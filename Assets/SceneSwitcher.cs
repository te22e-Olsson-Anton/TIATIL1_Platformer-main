using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void knapp1()
    {
        SceneManager.LoadScene(1);
    }

    public void knappHighscore2()
    {
        SceneManager.LoadScene(4);
    }

    public void knappBackToMeny()
    {
        SceneManager.LoadScene(0);
    }
}
