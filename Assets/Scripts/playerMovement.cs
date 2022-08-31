using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Vector3 playerLocation;
    public float moveSpeed=13;

    public float health=100;
    public bool inTheLevel=false;
    public Vector2 newPos = new Vector2();
    public Vector2 direction = Vector2.zero;
    public float angle;

    public int score=0;
   

  
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        checkCol();
        
    }
    public void checkCol()
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
    public void MovePlayer()
    {
        // yksikkö vektori ottaa suunnan wasdista tällä hetkellä
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        
        Vector2 movement = new Vector2( direction.x*moveSpeed*Time.deltaTime ,  direction.y *moveSpeed * Time.deltaTime);
        Debug.Log(movement);
        transform.Translate(movement);
        

        // yksikkö vektori antaa suunnan joka kerrotaan movespeedillä ja delta timellä

        //tämä lisätään sijaintiin
    }
    public void damagePlayerSlow(float _damage)
    {
        health=health - _damage*Time.deltaTime;
        
    }
    
   
    private void OnTriggerExit2D(Collider2D collision)
    {
            inTheLevel = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            Debug.Log("colsty");
            inTheLevel = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("colent");
            inTheLevel = true;
    }


}
