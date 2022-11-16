using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class enemyPlane : MonoBehaviour
{
    public List<Vector2> patrolRoute;
    public int numberOfLocationPoints;
    public Rigidbody2D rb;
    public GameObject player;
    public float PlotingTimerTarget = 0;
    float Plotingtimer = 0;
    public int currentTargetPosInRoute;
    public float tolereance;
    public float trackFrequency = 0.2f;
    public float trackFrequencyTimer = 0;
    public float maxSpeed = 200;
    public GameObject particles;
    LineRenderer lineRenderer => GetComponent<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<playerScripts>().gameObject;
        currentTargetPosInRoute = 6;
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlane();
        limitSpeed();
        flyingAndTrack();


    }
    public void takeDamage()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void flyingAndTrack()
    {
        if (PlotingTimerTarget > Plotingtimer & numberOfLocationPoints > 0)
        {
            Plotingtimer += 1 * Time.deltaTime;

        }
        else if (PlotingTimerTarget < Plotingtimer & numberOfLocationPoints > 0)
        {
            Plotingtimer = 0;
            numberOfLocationPoints -= 1;
            patrolRoute.Add(player.transform.position);
            rb.AddForce(new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y), ForceMode2D.Impulse);
        }
        else if (trackFrequency < trackFrequencyTimer)
        {

            trackFrequencyTimer = 0;
            if (new Vector2(patrolRoute[currentTargetPosInRoute].x - transform.position.x, patrolRoute[currentTargetPosInRoute].y - transform.position.y).magnitude < tolereance)
            {

                if (currentTargetPosInRoute > 0)
                {
                    currentTargetPosInRoute--;
                }
                else if (currentTargetPosInRoute == 0)
                {
                    currentTargetPosInRoute = patrolRoute.Count - 1;
                }
            }
            else
            {
                rb.AddForce(new Vector2(patrolRoute[currentTargetPosInRoute].x - transform.position.x, patrolRoute[currentTargetPosInRoute].y - transform.position.y), ForceMode2D.Impulse);
            }

        }
        else if (trackFrequency > trackFrequencyTimer)
        {
            trackFrequencyTimer += 1 * Time.deltaTime;
        }
    }
    void rotatePlane()
    {
        var dir = rb.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
    void limitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            //scale vector to correct magnitude

            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision == FindObjectOfType<playerScripts>().circleCollider)
        {
            FindObjectOfType<missileWarningSystem>().reciveEnemyData(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision == FindObjectOfType<playerScripts>().circleCollider)
        {
            FindObjectOfType<missileWarningSystem>().removeEnemyData(this.transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<powerUp>())
        {
            Destroy(collision.collider.gameObject);
        }
    }
}