using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineData :MonoBehaviour
{
   
    public LineRenderer lineRenderer;
    public Transform EnemyTransform;
    public Transform playerTrfrm;
    public void Update()
    {
        nullCheck();
    }
    public void addlineData(GameObject _LRGO,Transform _enemyTrfrm)
    {
        
        EnemyTransform= _enemyTrfrm;
        playerTrfrm = GameObject.FindObjectOfType<playerScripts>().gameObject.transform;

    }
    public void updateLine()
    {
       
        List<Vector3> tmp = new List<Vector3>();
        tmp.Add(playerTrfrm.position);
        tmp.Add(EnemyTransform.position);
       
        lineRenderer.SetPositions(tmp.ToArray());

    }
    public void nullCheck()
    {
       
        if(EnemyTransform == null)
        {
            lineRenderer.positionCount=0;
            
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
       
        
    }

}
