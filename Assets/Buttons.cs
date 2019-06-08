using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Menu()
    {
        int counter = 0;
        PlayerPrefs.SetInt("High Score", counter);
        int counter1 = 0;
        PlayerPrefs.SetInt("High Score 1", counter1);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        int counter = 0;
        PlayerPrefs.SetInt("High Score", counter);
        int counter1 = 0;
        PlayerPrefs.SetInt("High Score 1", counter1);
        Application.Quit();
    }
}
