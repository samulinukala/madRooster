using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public playerMovement playerMovement;
    public float maxSpeed=40;
    public float trackInterval=0;
    public float trackIntervalTarget=0.75f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement=FindObjectOfType<playerMovement>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    public void takeDamage()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
        trackPlayer();
        limitSpeed();
        Debug.Log(rigidbody2D.velocity.magnitude);
    }
    void rotatePlayer()
    {
        var dir = rigidbody2D.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rigidbody2D.MoveRotation(angle);
    }
    void limitSpeed()
    {
        if(rigidbody2D.velocity.magnitude > maxSpeed)
        {
            //scale vector to correct magnitude
         
          rigidbody2D.velocity= rigidbody2D.velocity.normalized*maxSpeed;
        }
    }
    void trackPlayer()
    {
        if (trackIntervalTarget < trackInterval)
        {
            trackInterval = 0;
            rigidbody2D.AddForce(new Vector2(playerMovement.gameObject.transform.position.x - transform.position.x, playerMovement.gameObject.transform.position.y - transform.position.y),ForceMode2D.Impulse);
        }
        else if(trackIntervalTarget > trackInterval)
        {
            trackInterval += 1 * Time.deltaTime;
        }
       
    }
 
}
