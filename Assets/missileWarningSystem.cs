using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileWarningSystem : MonoBehaviour
{
    public GameObject Pl;
    public GameObject En;
    LineRenderer lineRenderer;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer = En.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //nullCheckTheLines();
        updateLinesToTargets();
    }
    public void nullCheckTheLines()
    {
        //foreach (var line in missileLines)
        //{
        //    if (line.Key == null)
        //    {
        //        missileLines.Remove(line.Key);
        //    }
        //}
    }
    public void updateLinesToTargets()
    {

        Debug.Log(Pl.transform.position + "   "+ En.transform.position);

        lineRenderer.SetPosition(0, Pl.transform.position);
        lineRenderer.SetPosition(1, En.transform.position);



        //List<Vector3> help = new List<Vector3>();
        //help.Add(Pl.transform.position);
        //help.Add(En.transform.position);
        

        //var tmp = new List<Vector3>();
        //tmp.Add(transform.position);
        //tmp.Add( missileLines.transform.position);
        //lineRenderer.startWidth = 1f;
        //lineRenderer.endWidth = 0.1f;
        //lineRenderer.SetPositions(help.ToArray());        
        //lineRenderer.useWorldSpace = true;
        //line.Value.SetPositions(tmp.ToArray());
        //line.Value.sortingOrder = 9000;               
    }

    public void reciveEnemyData(GameObject collision) 
    {
        Debug.Log("enemy");
        
            //Debug.Log("enemy");
            //missileLines.Add(collision.gameObject, collision.gameObject.GetComponent<enemy>());
            //collision.GetComponent<LineRenderer>().enabled = true;
        
    }
    public void removeEnemyData(GameObject collision)
    {
       
            //Debug.Log("enemyLeft");
            //missileLines[collision.gameObject].enabled = false;
            //missileLines.Remove(collision.gameObject);
        
    }
}
