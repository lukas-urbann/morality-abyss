using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrystalPallet : MonoBehaviour
{
    public GameObject[] crystals;
    [SerializeField]private int _crystalCount = 0;
    private Animator fadeAnim;
    public AudioClip thunder;
    public AudioSource audioSource;

    void Start()
    {
        fadeAnim = GameObject.Find("WinFade").GetComponent<Animator>();
    }

    public void CrystalInsert(string name)
    {
        for (int i = 0; i < crystals.Length; i++)
        {
            if (name.Equals(crystals[i].name))
            {
                _crystalCount++;
                crystals[i].SetActive(true);
                PostCrystalInsert();
            }
        }
    }

    private void PostCrystalInsert()
    {
        if (_crystalCount == 6)
        {
            StartCoroutine(GameWin());
        }
    }

    IEnumerator GameWin()
    {
        audioSource.PlayOneShot(thunder);
        fadeAnim.SetTrigger("fade");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(3);
    }
}
