using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMovement : MonoBehaviour
{
    public float timerJiggle=0;
    public float timerJiggleTarget=5;
    public float Jigglerange;
    public float jiggleSpeed;
    public float updownSpeed;
    public float updownRangeTop;
    public float updownRangeBottom;
    public Vector3 calcPos;
  
    // Start is called before the first frame update
    public Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;   
        calcPos = startPos;
    }
    // Update is called once per frame
    void Update()
    {
       
        SineWaveMove();
        jiggle();
    }
    public void jiggle()
    {
        //should chenge rotation
       // new Vector3(calcPos.x, Mathf.Sin(updownSpeed * Time.deltaTime);


    }
    public void SineWaveMove()
    {
        if (transform.position.y < updownRangeTop)
            //linear interpolation
        {
            calcPos = new Vector3(calcPos.x, calcPos.y + Mathf.Sin(updownSpeed * Time.deltaTime), transform.position.z);
            transform.position = calcPos;
        }
        else if(transform.position.y > updownRangeBottom)
        {
            calcPos = new Vector3(calcPos.x, calcPos.y - Mathf.Sin(updownSpeed * Time.deltaTime), transform.position.z);
            transform.position = calcPos;
        }
    }
}
