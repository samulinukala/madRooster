using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class gameManager : MonoBehaviour
{
    public Button restartButton;
    public float survivalTimer;
    public bool gameOver;
    public TMP_Text scoreText;
    public playerMovement playerMovement;
    public GameObject GameOverCanvas;

    public AudioSource GameOverAudioSource;
    public AudioSource RestartAudioSource;
    public AudioSource GameMusic;
    public bool doOnce = false;

    public IEnumerator SoundTimer()
    {
        GameOverCanvas.SetActive(false);
        RestartAudioSource.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
    public IEnumerator GameOverTimer()
    {        
        GameOverAudioSource.Play();
        yield return new WaitForSeconds(0.4f);
    }
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        GameMusic.Play();
    }
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
        else if (gameOver == true && doOnce == false)
        {            
            StartCoroutine(GameOverTimer());
            GameOverCanvas.SetActive(true);
            FindObjectsOfType<enemyPlane>().ToList().ForEach(e => e.gameObject.SetActive(false));
            FindObjectsOfType<enemy>().ToList().ForEach(e => e.gameObject.SetActive(false));
            FindObjectsOfType<spawnScript>().ToList().ForEach(e => e.gameObject.SetActive(false));
            doOnce = true;
        }
    }

    public void Restart()
    {
        StartCoroutine(SoundTimer());
    }
}
