using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    public bool mapOn = false;
    public RawImage map;

    public void getItem(string itemName)
    {
        items.Add(itemName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ShowMap();
        }
    }

    public void ShowMap()
    {
        if (!gameObject.GetComponent<Player_Pause>().pause)
        {
            mapOn = !mapOn;

            map.gameObject.SetActive(mapOn);
            Player_Controller.instance.canMove = !mapOn;
        }
    }
}
