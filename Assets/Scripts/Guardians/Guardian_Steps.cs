using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Steps : MonoBehaviour
{
    public AudioClip stepSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.clip = stepSound;
        StartCoroutine(Steps());
    }

    IEnumerator Steps()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Steps());
    }
}