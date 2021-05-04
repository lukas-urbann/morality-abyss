 using UnityEngine;
 using System.Collections;
 
 public class Hand_Sway : MonoBehaviour {
     
    public float min = 0.04f;
    public float max = 0.075f;
    public float smooth = 6f;
    private Vector3 curP;
    
    void Start()
    {
        curP = transform.localPosition;
    }

    void FixedUpdate()
    {
        float movX = -Input.GetAxis("Mouse X") * min;
        float movY = -Input.GetAxis("Mouse Y") * min;
    
        movX = Mathf.Clamp(movX, -max, max);
        movY = Mathf.Clamp(movY, -max, max);

        Vector3 finalPosition = new Vector3(movX, movY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + curP, Time.deltaTime * smooth);
    }
 }