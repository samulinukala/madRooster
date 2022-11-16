using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPadAim : MonoBehaviour
{
    public GameObject touchPadCenter;
    public GameObject touchPadStick;
    public bool touchPadPressed = false;
    public Vector2 touchpadDir;
    public float touchpadDist;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPadStick.SetActive(true);
            touchPadCenter.SetActive(true);
         
            touchPadPressed = true;
            touchPadCenter.transform.position = Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            touchPadStick.transform.position=Input.mousePosition;
            touchpadDir=touchPadStick.transform.position-touchPadCenter.transform.position;
            touchpadDir.Normalize();
            Debug.Log(touchpadDir);
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchPadPressed=false;
            touchPadCenter.SetActive(false);
            touchPadStick.SetActive(false);
        }
        
    }
}
