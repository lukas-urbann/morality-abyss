﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Raycast : MonoBehaviour
{
    public Text pickUpText;
    private bool _pickable;
    private Player_Inventory _pInventory;
    private AudioSource _audioSource;
    public AudioClip unknownAction, openAction;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        pickUpText.enabled = false;
        _pInventory = transform.parent.gameObject.GetComponent<Player_Inventory>();
    }
    
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (PickCheck(hit))
            {
                pickUpText.enabled = true;
                switch(hit.collider.GetComponent<Items_Identity>().interaction)
                {
                    case Items_Identity.itemType.pick:
                        if(Input.GetKeyDown(KeyCode.E))
                        {
                            _audioSource.Play();
                            _pInventory.getItem(getItemID(hit.collider.gameObject));
                            Destroy(hit.collider.gameObject);
                        } 
                        pickUpText.text = "Pick up " + "<" + hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                    break;
                    case Items_Identity.itemType.open:
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            string neededKey = hit.collider.GetComponent<Items_Identity>().requiredKey;
                            for (int i = 0; i < _pInventory.items.Count; i++)
                            {
                                if (_pInventory.items[i].Equals(neededKey))
                                {
                                    Debug.Log("mameklicek");
                                }
                                else
                                {
                                    _audioSource.PlayOneShot(unknownAction);
                                }
                            }
                        }
                        pickUpText.text = "Open " + "<" + hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                    break;
                    case Items_Identity.itemType.use:
                        pickUpText.text = "Use " + "<" + hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                    break;
                    case Items_Identity.itemType.destroy:
                        pickUpText.text = "Destroy " + "<" + hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                    break;
                }
            }
            else
            {
                pickUpText.enabled = false;
            }
        }
        else
        {
            pickUpText.enabled = false;
        }
    }

    string getItemID(GameObject item)
    {
        return item.GetComponent<Items_Identity>().retrieveValue;
    }
    
    bool PickCheck(RaycastHit hit)
    {
        var isIt = hit.collider.GetComponent<Items_Identity>();
        if (isIt != null && isIt.interactable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
