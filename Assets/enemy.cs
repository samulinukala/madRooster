
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public playerMovement playerMovement;
    public float maxSpeed=40;
    public float trackInterval=0;
    public float trackIntervalTarget=0.75f;
    public float turnspeed=5f;
    public GameObject particles;
    [Range(0,100)]
    public float PowerUpDropChance;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement=FindObjectOfType<playerMovement>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
    }
    public void takeDamage()
    {

        Instantiate(particles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    void dropPowerUp()
    {
        float rand=Random.Range(0,PowerUpDropChance);
        if (PowerUpDropChance < rand)
        {
            var tmp=Instantiate(powerUp);
            tmp.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
        trackPlayer();
        limitSpeed();
     
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
        if (rigidbody2D.angularVelocity > turnspeed)
        {
            turnspeed = rigidbody2D.angularVelocity;
        }
    }
   
    void trackPlayer()
    {
        
            rigidbody2D.AddForce(new Vector2(playerMovement.gameObject.transform.position.x - transform.position.x, playerMovement.gameObject.transform.position.y - transform.position.y),ForceMode2D.Force);
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision == FindObjectOfType<playerMovement>().circleCollider)
        {
            FindObjectOfType<missileWarningSystem>().reciveEnemyData(this.transform);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<enemyPlane>() != null)
        {

            takeDamage();

        }
        if (collision.gameObject.GetComponent<enemy>() != null)
        {
            if (collision.gameObject.GetComponent<enemy>() != this.gameObject.GetComponent<enemy>())
            {
                collision.gameObject.GetComponent<enemy>().takeDamage();
                takeDamage();
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision == FindObjectOfType<playerMovement>().circleCollider)
        {
            FindObjectOfType<missileWarningSystem>().removeEnemyData(this.transform);
        }
    }

}
