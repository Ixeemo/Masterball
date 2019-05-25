using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseModel : MonoBehaviour
{
    private GameObject[] modelsList;
    private int index;
    private movement autobot = new movement();

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        modelsList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            modelsList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in modelsList)
            go.SetActive(false);

        if (Enumerable.Range(1, modelsList.Length).Contains(index))
        {
            
        }
        else
        {
            index = 0;
        }

            if (modelsList[index])
            modelsList[index].SetActive(true);
    }

    public void NextPlayer1()
    {
        modelsList[index].SetActive(false);
        index++;
        if (index == modelsList.Length) //czy tu ma być -1 czy nie?
            index = 0;

        modelsList[index].SetActive(true);

    }

    public void PreviousPlayer1()
    {
        modelsList[index].SetActive(false);
        index--;
        if (index < 0)
            index = modelsList.Length - 1;

        modelsList[index].SetActive(true);
                
    }

    

    public void Back()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(0);
    }
}
