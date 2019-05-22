using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ItemSelection : MonoBehaviour
{

    //public Image SelectionImagePlayer1;
    //public Image SelectionImagePlayer2;
    public GameObject SpaceShuttlePlayer1;
    public List<GameObject> ItemListPlayer1 = new List<GameObject>();
    //public List<Sprite> ItemListPlayer1 = new List<Sprite>();
    //public List<Sprite> ItemListPlayer2 = new List<Sprite>();
    private int itemSpotPlayer1 = 0;
    private int itemSpotPlayer2 = 0;

    public void NextPlayer1()
    {
        if (itemSpotPlayer1 < ItemListPlayer1.Count - 1)
        {
            itemSpotPlayer1++;
            //SelectionImagePlayer1.sprite = ItemListPlayer1[itemSpotPlayer1];
            SpaceShuttlePlayer1 = ItemListPlayer1[itemSpotPlayer1];
        }            
    }

    public void PreviousPlayer1()
    {
        if (itemSpotPlayer1 > 0)
        {
            itemSpotPlayer1--;
            //SelectionImagePlayer1.sprite = ItemListPlayer1[itemSpotPlayer1];
            SpaceShuttlePlayer1 = ItemListPlayer1[itemSpotPlayer1];
        }
    }

    /*
    public void NextPlayer2()
    {
        if (itemSpotPlayer2 < ItemListPlayer2.Count - 1)
        {
            itemSpotPlayer2++;
            SelectionImagePlayer2.sprite = ItemListPlayer2[itemSpotPlayer2];
        }
    }

    public void PreviousPlayer2()
    {
        if (itemSpotPlayer2 > 0)
        {
            itemSpotPlayer2--;
            SelectionImagePlayer2.sprite = ItemListPlayer2[itemSpotPlayer2];
        }
    }
    */

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
