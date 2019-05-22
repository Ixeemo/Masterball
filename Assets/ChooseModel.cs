using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseModel : MonoBehaviour
{
    private GameObject[] modelsList;
    private int index;

    private void Start()
    {
        modelsList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            modelsList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in modelsList)
            go.SetActive(false);

        if (modelsList[0])
            modelsList[0].SetActive(true);
    }

    public void NextPlayer1()
    {
        Debug.Log("Weszlo");
        modelsList[index].SetActive(false);
        index++;
        if (index == modelsList.Length-1) //czy tu ma być -1 czy nie?
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
        SceneManager.LoadScene(0);
    }
}
