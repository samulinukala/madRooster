using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMovement>().powerUpActive = true;
            Destroy(gameObject);
        }
    }
}
