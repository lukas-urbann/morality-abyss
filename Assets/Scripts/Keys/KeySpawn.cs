using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    [SerializeField]private GameObject[] keys;

    public void SpawnKeys()
    {
        float rand = Random.Range(0, 10);
        if (rand > 5)
        {
            keys[0].SetActive(true);
            keys[1].SetActive(false);
        }
        else
        {
            keys[0].SetActive(false);
            keys[1].SetActive(true);
        }
    }
}
