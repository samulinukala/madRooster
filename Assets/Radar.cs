using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    public Camera radarCam;
  
    public RawImage radarData;
    public RenderTexture renderTexture;
    public float timer=0;
    public float timerTarget=0.1f;
   

    // how it is supposed to work
    //get a screen shot from the radar camera that has the enemy in a layer that shows points that are on the enemy prefabs
    //put the screenshot in to the radar data image
    private void Awake()
    {
        radarData.texture = renderTexture;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > timerTarget)
        {
            
                radarCam.enabled = true;
              
              

            
           
            
            timer = 0;
        }
        else if(timer < timerTarget)
        {
            timer+=1*Time.deltaTime;
            radarCam.enabled = false;
        }

        
    }
  
    
    

    
  
}
