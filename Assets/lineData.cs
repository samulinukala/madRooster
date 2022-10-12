using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineData :MonoBehaviour
{
   
    public LineRenderer lineRenderer;
    public Transform EnemyTransform;
    public Transform playerTrfrm;
    
    public void addlineData(GameObject _LRGO,Transform _enemyTrfrm)
    {
        
        EnemyTransform= _enemyTrfrm;
        playerTrfrm = GameObject.FindObjectOfType<playerMovement>().gameObject.transform;

    }
    public void updateLine()
    {
        nullCheck();
        List<Vector3> tmp=new();
        tmp.Add(playerTrfrm.position);
        tmp.Add(EnemyTransform.position);
        lineRenderer.SetPositions(tmp.ToArray());

    }
    public void nullCheck()
    {
       
        if(EnemyTransform == null)
        {
            Destroy(gameObject);
        }
       
        
    }

}
