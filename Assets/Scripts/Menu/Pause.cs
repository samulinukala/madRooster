using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class Pause : MonoBehaviour
{
    public Button pauseButton;
    public bool pauseEnabled;
    
    public Sprite pauseSprite1;
    public Sprite pauseSprite2;
    public void PauseMethod()
    {
        if (pauseEnabled == false)
        {
            pauseEnabled = true;
            Time.timeScale = 0;
            pauseButton.image.sprite = pauseSprite2;
        }
        else if (pauseEnabled == true)
        {
            pauseEnabled = false;
            Time.timeScale = 1;
            pauseButton.image.sprite = pauseSprite1;
        }
    }
}



