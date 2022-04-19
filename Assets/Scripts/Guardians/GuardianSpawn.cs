using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSpawn : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject guardian;

    public void SpawnGuardians()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            Instantiate(guardian, spawns[i].transform.position, guardian.transform.rotation);
        }
    }
}
