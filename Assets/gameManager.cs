using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float survivalTimer;
    public bool gameOver;
    public TMP_Text scoreText;
    public playerMovement playerMovement;
    // Start is called before the first frame update

    private void Awake()
    {
        playerMovement=FindObjectOfType<playerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        gameOver = playerMovement.IsAlive;
        if (gameOver==false)
        {
            survivalTimer += 1 * Time.deltaTime;
            scoreText.text =((int) survivalTimer).ToString();



            Time.timeScale = 0;
        }
    }
}
