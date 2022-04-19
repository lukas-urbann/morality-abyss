using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject[] crystals;
    [SerializeField]private GuardianSpawn GuardianSpawner;

    void Start()
    {
        GuardianSpawner = GameObject.Find("Guardian Spawns").GetComponent<GuardianSpawn>();
    }
    
    public void SpawnCrystals()
    {
        for (int i = 0; i < crystals.Length; i++)
        {
            crystals[i].SetActive(true);
        }
    }

    public void SpawnGuardians()
    {
        GuardianSpawner.SpawnGuardians();
    }
}
