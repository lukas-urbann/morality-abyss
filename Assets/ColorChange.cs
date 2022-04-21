using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    [SerializeField] private string buttonTextName = "Text";
    public Color selectedTextColor, defaultColor;

    private void Start()
    {
        if(buttonTextName != "0_EMPTY")
        {
            buttonText = gameObject.transform.Find(buttonTextName).GetComponent<Text>();
            defaultColor = buttonText.color;
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonTextName != "0_EMPTY")
            buttonText.color = selectedTextColor; //Or however you do your color
        
        if (gameObject.GetComponent<Image>() != null)
            gameObject.GetComponent<Image>().color = selectedTextColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(buttonTextName != "0_EMPTY")
            buttonText.color = defaultColor; //Or however you do your color

        if (gameObject.GetComponent<Image>() != null)
            gameObject.GetComponent<Image>().color = defaultColor;
    }

    public void ColorReset()
    {
        if(buttonTextName != "0_EMPTY")
            buttonText.color = defaultColor; //Or however you do your color

        if (gameObject.GetComponent<Image>() != null)
            gameObject.GetComponent<Image>().color = defaultColor;
    }
}
