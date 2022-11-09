using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartButton;
    public AudioSource MenuMusic;
    private void Start()
    {
        MenuMusic.Play();
    }

    public void OnMouseUp(Button start)
    {       
        Debug.Log("Button pressed");       
        SceneManager.LoadScene(1);        
    }
}
