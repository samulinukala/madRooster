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
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
    }
    void rotatePlayer()
    {
        var dir = rigidbody2D.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rigidbody2D.MoveRotation(angle);
    }
    void trackPlayer()
    {
    
    }
}
