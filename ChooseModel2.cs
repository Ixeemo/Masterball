using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseModel : MonoBehaviour
{
    private GameObject[] modelsList;
    private int index;


    void Start()
    {
        //PlayerPrefs.DeleteKey("CharacterSelected");
        //PlayerPrefs.SetInt("CharacterSelected", index);
        index = PlayerPrefs.GetInt("CharacterSelected");
        modelsList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            modelsList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in modelsList)
            go.SetActive(false);

        if (modelsList[index])
            modelsList[index].SetActive(true);

    }

    public void NextPlayer1()
    {
        modelsList[index].SetActive(false);
        index++;
        if (index == modelsList.Length)
            index = 0;

        modelsList[index].SetActive(true);
        Debug.Log("next:" + index);

    }

    public void PreviousPlayer1()
    {
        modelsList[index].SetActive(false);
        index--;
        if (index < 0)
            index = modelsList.Length - 1;

        modelsList[index].SetActive(true);
        Debug.Log("previous:" + index);


    }

    public void Back()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        Debug.Log("play:" + index);

    }
}
