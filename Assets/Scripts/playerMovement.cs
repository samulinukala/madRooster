using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    private Vector3 playerLocation;
    public float moveSpeed=13;
    public PlayerInput input;
    public int health=4;
    public bool inTheLevel=false;
    public Vector2 newPos = new Vector2();
    public Vector2 direction = Vector2.zero;
    public float angle;
    public Vector3 rotationVector;
    public int score=0;
    public Rigidbody2D Rigidbody2D;
    public float turnspeed = 5f;
    public Collider2D circleCollider;
    public bool IsAlive => health < 0;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<Collider2D>();
        input = GetComponent<PlayerInput>();
        playerLocation = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        MovePlayer();
        rotatePlayer();
     
        
    }
    private void rotatePlayer()
    {

        var dir = Rigidbody2D.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Rigidbody2D.MoveRotation(angle);



    }
    private void checkCol()
    {
        if (inTheLevel == false)
        {

            if (transform.position.x < -200)
            {
                newPos.x = -200;
                newPos.y = transform.position.y;
                transform.position = newPos;

            }
            else
            if (transform.position.x > 200)
            {
                newPos.x = 200;
                newPos.y = transform.position.y;
                transform.position = newPos;
            }
            if (transform.position.y < -200)
            {
                newPos.y = -200;
                newPos.x = transform.position.x;
                transform.position = newPos;
            }
            else
            if (transform.position.y > 200)
            {
                newPos.y = 200;
                newPos.x = transform.position.x;
                transform.position = newPos;
            }

        }

    }
    private void MovePlayer()
    {
        
        Vector2 direction = Vector2.zero;
        
      direction = input.actions["move"].ReadValue<Vector2>();

        Vector2 movement = new Vector2( direction.x*moveSpeed*Time.deltaTime ,  direction.y *moveSpeed * Time.deltaTime);
  
       Rigidbody2D.AddForce(movement,ForceMode2D.Force);

        if (Rigidbody2D.angularVelocity > turnspeed)
        {
            turnspeed = Rigidbody2D.angularVelocity;
        }

    }
   
    public void damagePlayer()
    {
        health = health - 1;
        
    }
    
   
    private void OnTriggerExit2D(Collider2D collision)
    {
            inTheLevel = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
    
            inTheLevel = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            
            inTheLevel = true;
    }
   

}
