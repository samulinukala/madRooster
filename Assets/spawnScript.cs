using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public float timer=0;
    public float timerTarget = 5;
    public GameObject spawnedEnemy;
    // Update is called once per frame
    void Update()
    {
        if (timer < timerTarget)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        if (timer > timerTarget)
        {
            timer=0;
            Instantiate(spawnedEnemy,transform.position,transform.rotation);
        }
    }
}
