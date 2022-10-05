using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileWarningSystem : MonoBehaviour
{
    private Dictionary<GameObject, LineRenderer> missileLines = new();
   
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nullCheckTheLines();
        updateLinesToTargets();
    }public void nullCheckTheLines()
    {
        foreach (var line in missileLines)
        {
            if (line.Key == null)
            {
                missileLines.Remove(line.Key);
            }
        }
    }
    public void updateLinesToTargets()
    {
        foreach(var line in missileLines)
        {
            Debug.Log("update line");
            var tmp = new List<Vector3>();
            tmp.Add(transform.position);
            tmp.Add(line.Key.transform.position);
            line.Value.SetPositions(tmp.ToArray());
            line.Value.sortingOrder = 9000;

        }
    }

    public void reciveEnemyData(GameObject collision) 
    {
        Debug.Log("enemy");
        
            Debug.Log("enemy");
            missileLines.Add(collision.gameObject, collision.gameObject.GetComponent<LineRenderer>());
            collision.GetComponent<LineRenderer>().enabled = true;
        
    }
    public void removeEnemyData(GameObject collision)
    {
       
            Debug.Log("enemyLeft");
            missileLines[collision.gameObject].enabled = false;
            missileLines.Remove(collision.gameObject);
        
    }
}
