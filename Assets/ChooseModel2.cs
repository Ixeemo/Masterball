using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseModel2 : MonoBehaviour
{
    private GameObject[] modelsList2;
    private int index2;


    void Start()
    {
        //PlayerPrefs.DeleteKey("CharacterSelected");
        //PlayerPrefs.SetInt("CharacterSelected", index);
        index2 = PlayerPrefs.GetInt("CharacterSelected2");
        modelsList2 = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            modelsList2[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in modelsList2)
            go.SetActive(false);

        if (modelsList2[index2])
            modelsList2[index2].SetActive(true);

    }

    public void NextPlayer1()
    {
        modelsList2[index2].SetActive(false);
        index2++;
        if (index2 == modelsList2.Length)
            index2 = 0;

        modelsList2[index2].SetActive(true);
        Debug.Log("next:" + index2);

    }

    public void PreviousPlayer1()
    {
        modelsList2[index2].SetActive(false);
        index2--;
        if (index2 < 0)
            index2 = modelsList2.Length - 1;

        modelsList2[index2].SetActive(true);
        Debug.Log("previous:" + index2);


    }

    public void Back()
    {
        PlayerPrefs.SetInt("CharacterSelected2", index2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("CharacterSelected2", index2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        Debug.Log("play:" + index2);

    }
}
