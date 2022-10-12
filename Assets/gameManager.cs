using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public Button restartButton;
    public float survivalTimer;
    public bool gameOver;
    public TMP_Text scoreText;
    public playerMovement playerMovement;
    public GameObject GameOverCanvas;
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
        }
        else if (gameOver == true)
        {
            GameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        GameOverCanvas.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
