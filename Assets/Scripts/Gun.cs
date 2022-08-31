using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public playerMovement playerMovement;
    public GameObject projectilePrefab;
    public GameObject projectileSpawn;
    public GameObject TmpProjectile;
    public float fireCalc;
    public bool canFire;
    public float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    public void handleFire()
    {

        Debug.Log("fire");
        if (canFire == true)
        {
            TmpProjectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, transform.rotation);
            TmpProjectile.transform.parent = gameObject.transform;
            canFire = false;
        }
        else
        if (fireCooldown > fireCalc)
        {
            fireCalc = fireCalc + 1 * Time.deltaTime;
        }
        else if (fireCooldown < fireCalc)
        {

            canFire = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        handleFire();
        //playerMovement.contAHor = Input.GetAxis("AimHorizontalController" + playerMovement.playerNum);
        //playerMovement.contAVer = Input.GetAxis("AimVerticalController" + playerMovement.playerNum);

       
            playerMovement.angle = Mathf.Atan2(-playerMovement.direction.y, -playerMovement.direction.x);
            transform.rotation = Quaternion.EulerAngles(0, 0, playerMovement.angle);

        }

    }
}
