using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Raycast : MonoBehaviour
{
    public Text pickUpText;
    private bool _pickable;
    private Player_Inventory _pInventory;
    private AudioSource _audioSource;
    public AudioClip unknownAction, thunder;
    private Player_BatteryLife _pBat;
    public RawImage notePaper;
    private bool _isReading = false;

    void Start()
    {
        _pBat = transform.parent.gameObject.GetComponent<Player_BatteryLife>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        pickUpText.enabled = false;
        _pInventory = transform.parent.gameObject.GetComponent<Player_Inventory>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
            if (PickCheck(hit))
            {
                pickUpText.enabled = true;
                switch (hit.collider.GetComponent<Items_Identity>().interaction)
                {
                    case Items_Identity.itemType.pick:
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _audioSource.Play();
                            switch (hit.collider.GetComponent<Items_Identity>().retrieveValue)
                            {
                                case "battery":
                                    _pBat.RefillBattery();
                                    break;
                                case "c_envy":
                                    _audioSource.PlayOneShot(thunder);
                                    hit.collider.gameObject.GetComponent<CrystalSpawner>().SpawnCrystals();
                                    hit.collider.gameObject.GetComponent<CrystalSpawner>().SpawnGuardians();
                                    _pInventory.getItem(getItemID(hit.collider.gameObject));
                                    break;
                                default:
                                    _pInventory.getItem(getItemID(hit.collider.gameObject));
                                    break;
                            }
                            Destroy(hit.collider.gameObject);
                        }

                        pickUpText.text = "Pick up " + "<" +
                                          hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                        break;
                    case Items_Identity.itemType.open:
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            string neededKey = hit.collider.GetComponent<Items_Identity>().requiredKey;
                            for (int i = 0; i < _pInventory.items.Count; i++)
                            {
                                if (_pInventory.items[i].Equals(neededKey))
                                {
                                    Animator anim = hit.collider.gameObject.transform.root.GetComponent<Animator>();
                                    anim.SetTrigger("open");
                                }
                                else
                                {
                                    _audioSource.PlayOneShot(unknownAction);
                                }
                            }
                        }

                        pickUpText.text = "Open " + "<" +
                                          hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                        break;
                    case Items_Identity.itemType.use:
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            switch (hit.collider.GetComponent<Items_Identity>().retrieveValue)
                            {
                                case "d_pallet":
                                    for (int i = 0; i < _pInventory.items.Count; i++)
                                    {
                                        if (
                                            _pInventory.items[i].Equals("c_envy")
                                            ^_pInventory.items[i].Equals("c_gluttony")
                                            ^_pInventory.items[i].Equals("c_pride")
                                            ^ _pInventory.items[i].Equals("c_greed")
                                            ^_pInventory.items[i].Equals("c_lust")
                                            ^_pInventory.items[i].Equals("c_wrath")
                                            )
                                        {
                                            CrystalPallet c_Insert = hit.collider.gameObject.GetComponent<CrystalPallet>();
                                            c_Insert.CrystalInsert(_pInventory.items[i]);
                                            _pInventory.items.RemoveAt(i);
                                        }
                                        else
                                        {
                                            _audioSource.PlayOneShot(unknownAction);
                                        }
                                    }
                                    break;
                            }
                        }
                        pickUpText.text = "Use " + "<" +
                                          hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                        break;
                    case Items_Identity.itemType.destroy:
                        pickUpText.text = "Destroy " + "<" +
                                          hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
                        break;
                    case Items_Identity.itemType.read:
                        
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (!_isReading)
                            {
                                notePaper.texture = hit.collider.gameObject.GetComponent<Items_Identity>().noteImage;
                                notePaper.gameObject.SetActive(true);
                                _pBat.gameObject.GetComponent<Player_Controller>().canMove = false;
                                
                                if (hit.collider.gameObject.name.Equals("Note_ruins2"))
                                {
                                    KeySpawn keys = hit.collider.gameObject.GetComponent<KeySpawn>();
                                    keys.SpawnKeys();
                                }
                            }
                            else
                            {
                                notePaper.gameObject.SetActive(false);
                                _pBat.gameObject.GetComponent<Player_Controller>().canMove = true;
                            }

                            _isReading = !_isReading;
                        }
                        pickUpText.text = "Read " + "<" + hit.collider.gameObject.GetComponent<Items_Identity>().identity + ">";
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