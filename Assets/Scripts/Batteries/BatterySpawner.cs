using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject[] batteries;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, batteries.Length);

            if (batteries[index].activeSelf)
            {
                i--;
            }
            else
            {
                batteries[index].SetActive(true);
            }
        }
    }

}
