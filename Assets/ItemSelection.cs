using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemSelection : MonoBehaviour
{

    public Image SelectionImage;
    public List<Sprite> ItemList = new List<Sprite>();
    private int itemSpot = 0;

    public void Next()
    {
        if (itemSpot < ItemList.Count - 1)
        {
            itemSpot++;
            SelectionImage.sprite = ItemList[itemSpot];
        }
            
    }

    public void Previous()
    {
        if (itemSpot > 0)
        {
            itemSpot--;
            SelectionImage.sprite = ItemList[itemSpot];
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
