using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public void getItem(string itemName)
    {
        items.Add(itemName);
    }
}
