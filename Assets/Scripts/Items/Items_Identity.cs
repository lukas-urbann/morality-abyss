using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items_Identity : MonoBehaviour
{
    [Header("Display Name")]
    public string identity;
    [Header("id")]
    public string retrieveValue;
    [Header("Type of interaction")]
    public bool interactable;
    public itemType interaction;
    public enum itemType { pick, open, destroy, use, read};
    
    public string requiredKey;
    public Texture noteImage;

}
