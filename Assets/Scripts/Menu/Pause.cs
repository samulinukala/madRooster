using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class Pause : MonoBehaviour
{
    public Button pauseButton;
    public bool pauseEnabled;
    
    public void PauseMethod()
    {
        if (pauseEnabled == false)
        {
            pauseEnabled = true;
            Time.timeScale = 0;
        }
        else if (pauseEnabled == true)
        {
            pauseEnabled = false;
            Time.timeScale = 1;
        }
    }
}



