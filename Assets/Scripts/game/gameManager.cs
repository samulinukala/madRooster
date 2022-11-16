using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.Services.Mediation.Samples;
public class gameManager : MonoBehaviour
{
    public Button restartButton;
    public float survivalTimer;
    public bool gameOver;
    public TMP_Text scoreText;
    public playerScripts playerMovement;
    public GameObject GameOverCanvas;

    public AudioSource GameOverAudioSource;
    public AudioSource RestartAudioSource;
    public bool doOnce = false;

    public monetisationData monetisationData;
    public InterstitialExample interstitialExample;
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
        
    }
    private void Awake()
    {
        playerMovement=FindObjectOfType<playerScripts>();
    }
    // Update is called once per frame
    void Update()
    {
        gameOver = playerMovement.IsAlive;
        if (gameOver==false)
        {
            survivalTimer += 1 * Time.deltaTime;
            
            scoreText.text = "Score: " + ((int) survivalTimer).ToString();            
        }
        else if (gameOver == true && doOnce == false)
        {
            monetisationData.ammountOfTimesSinceAds += 1;
            StartCoroutine(GameOverTimer());
            GameOverCanvas.SetActive(true);
            FindObjectsOfType<enemyPlane>().ToList().ForEach(e => e.gameObject.SetActive(false));
            FindObjectsOfType<enemy>().ToList().ForEach(e => e.gameObject.SetActive(false));
            FindObjectsOfType<spawnScript>().ToList().ForEach(e => e.gameObject.SetActive(false));
            interstitialExample.ShowInterstitial();
            doOnce = true;
        }
    }

    public void Restart()
    {
        StartCoroutine(SoundTimer());
    }
}
