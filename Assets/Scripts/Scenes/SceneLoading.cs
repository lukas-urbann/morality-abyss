using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Text loadProgressText;
    private float _percentage;
    
    void Start()
    {
        StartCoroutine(AsyncOperatorLevel());
    }

    IEnumerator AsyncOperatorLevel()
    {
        AsyncOperation loadProgress = SceneManager.LoadSceneAsync(2);

        while (loadProgress.progress < 1)
        {
            _percentage = loadProgress.progress * 100;
            loadProgressText.text = _percentage.ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
    }
}
