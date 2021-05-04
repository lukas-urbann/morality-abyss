using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Camera cam;
    public TextMesh start, options, quit;
    public AudioClip selectSound;
    public AudioSource audioSource;
    
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform raycastObject = hit.transform;
            Debug.Log(raycastObject.gameObject.name);
            TextSelect(raycastObject.gameObject);

            if (Input.GetButtonDown("Fire1"))
            {
                Action(raycastObject.gameObject);
            }
        }
    }

    void TextSelect(GameObject selectedButton)
    {
        TextMesh meshComponent = selectedButton.GetComponent<TextMesh>();
        
        switch (selectedButton.name)
        {
            case "Start":
                meshComponent.color = Color.yellow;
                options.color = Color.white;
                quit.color = Color.white;
                break;
            case "Options":
                start.color = Color.white;
                meshComponent.color = Color.yellow;
                quit.color = Color.white;
                break;
            case "Quit":
                start.color = Color.white;
                options.color = Color.white;
                meshComponent.color = Color.yellow;
                break;
            default:
                start.color = Color.white;
                options.color = Color.white;
                quit.color = Color.white;
                break;
        }
    }

    void Action(GameObject selectedButton)
    {
        switch (selectedButton.name)
        {
            case "Start":
                audioSource.PlayOneShot(selectSound);
                break;
            case "Options":
                audioSource.PlayOneShot(selectSound);
                break;
            case "Quit":
                Application.Quit(69);
                break;
            default:
                Debug.Log("Miss");
                break;
        }
    }
}
