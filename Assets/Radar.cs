using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    public Camera radarCam;
  
    public RawImage radarData;
    public RenderTexture renderTexture;
   
    // how it is supposed to work
    //get a screen shot from the radar camera that has the enemy in a layer that shows points that are on the enemy prefabs
    //put the screenshot in to the radar data image
    
    // Update is called once per frame
    void Update()
    {
     radarData.texture=renderTexture;
      

        
    }
  
    
    

    
  
}
