using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class invincibilityEffect : MonoBehaviour
{
    public List<SpriteRenderer> spritesToFlicker=new();
    public bool invicible;
    public bool doOnce;
    public float timer=0;
    public float timerTarget=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (invicible)
        {
            doOnce = true;
            StartCoroutine(flicker());
            if (timer > timerTarget)
            {
                timer = 0;
                invicible = false;
            }else
            {
                timer +=1*Time.deltaTime;
            }
        }
        else
        {
            if (doOnce)
            {
                doOnce = false;
                foreach (SpriteRenderer sprite in spritesToFlicker)
                {
                    sprite.enabled = true;
                }
            }
        }
        
    }
    IEnumerator flicker()
    {
        foreach(SpriteRenderer sprite in spritesToFlicker)
        {
            sprite.enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (SpriteRenderer sprite in spritesToFlicker)
        {
            sprite.enabled = true;
        }
    } 
}
