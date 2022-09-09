using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public playerMovement playerMovement;
    
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
    }
    void rotatePlayer()
    {
        var dir = rigidbody2D.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rigidbody2D.MoveRotation(angle);
    }
    void trackPlayer()
    {
        rigidbody2D.AddForce(new Vector2(playerMovement.gameObject.transform.position.x - transform.position.x, playerMovement.gameObject.transform.position.y - transform.position.y));
    }
 
}
