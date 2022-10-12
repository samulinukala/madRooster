using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    public Camera radarCam;
    public Canvas canvas;
    public RawImage radarData;
    public RenderTexture renderTexture;
    public bool RadarShown=false;
    public bool radarAvailable = true;
    public float radarAvailableTimer = 0;
    public float radaravalableTimerTarget = 6;
    public float timer=0;
    public float timerTarget=6f;
    public Image button;
   

    // how it is supposed to work
    //get a screen shot from the radar camera that has the enemy in a layer that shows points that are on the enemy prefabs
    //put the screenshot in to the radar data image
    private void Awake()
    {
        radarData.texture = renderTexture;
        radarCam.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (RadarShown)
        {
            canvas.enabled = true;
            if (timer < timerTarget)
            {
                timer += Time.deltaTime;
                
            }
            else
            {
                timer = 0;
                RadarShown = false;
                radarAvailable = false;
            }
        }
        else
        {
            canvas.enabled = false;
            if (radarAvailable == false) {
                if (radarAvailableTimer < radaravalableTimerTarget)
                {
                    radarAvailableTimer += Time.deltaTime;
                }
                if (radarAvailableTimer > radaravalableTimerTarget)
                {
                    radarAvailableTimer = 0;
                    radarAvailable = true;
                    
                }
        } }
        if (RadarShown == true)
        {
            button.color = Color.yellow;
        }else
        if (radarAvailable)
        {
            button.color = Color.cyan;
        }else
        if (radarAvailable == false)
        {
            button.color = Color.red;
        }
      
       
        

        
    }
    public void changeRadar()
    {
        if (radarAvailable == true && RadarShown == false)
        {
            RadarShown = true;
           
        }
        
    }
  
    
    

    
  
}
