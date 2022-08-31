using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaiton : MonoBehaviour
{
    public playerMovement playerMovement;
    public GameObject projectilePrefab;
    public GameObject projectileSpawn;
    public GameObject TmpProjectile;
  
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    public void handleFire()
    {

        Debug.Log("fire");

        TmpProjectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, transform.rotation);
        TmpProjectile.transform.parent = gameObject.transform;


        //if (playerMovement.fireCooldown > playerMovement.fireCalc)
        //{
        //    playerMovement.fireCalc = playerMovement.fireCalc + 1 * Time.deltaTime;
        //}
        //else if (playerMovement.fireCooldown < playerMovement.fireCalc)
        //{

        //    playerMovement.canFire = true;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        handleFire();
        //playerMovement.contAHor = Input.GetAxis("AimHorizontalController" + playerMovement.playerNum);
        //playerMovement.contAVer = Input.GetAxis("AimVerticalController" + playerMovement.playerNum);

        //if (new Vector2(playerMovement.contAHor, playerMovement.contAVer).magnitude > playerMovement.deadZone)
        //{
        //    playerMovement.angle = Mathf.Atan2(-playerMovement.contAVer, -playerMovement.contAHor);
        //    transform.rotation = Quaternion.EulerAngles(0, 0, playerMovement.angle);

        //}

    }
}
