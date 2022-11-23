using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSimple : MonoBehaviour
{
    [Range(0,99)]
    public float upTarget;

   
    public float speed;
    public float speedTrue;
   
    public float startTime;
   
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
    }
   
    private void FixedUpdate()
    {


        speedTrue = Mathf.Sin(speed * Time.time - startTime) * upTarget;
        Vector3 I = new Vector3(transform.position.x, transform.position.y - 0, transform.position.z);
        Vector3 II = new Vector3(transform.position.x, transform.position.y + upTarget, transform.position.z);
        float t= Time.time - startTime ;

       

        //add emergency if statements that kick in whenit gets stuck 
        

            transform.position = new Vector3(transform.position.x, transform.position.y + speedTrue * Time.deltaTime, transform.position.z);
        //to do add wigles
     
    }
    
}
