using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileWarningSystem : MonoBehaviour
{
    public lineHolder lineHolder;
   
    
    
   
    // Start is called before the first frame update
    void Start()
    {
      lineHolder=FindObjectOfType<lineHolder>(); 
    }

    // Update is called once per frame
    void Update()
    {

        lineHolder.updateLines();
    }
    
  

    public void reciveEnemyData(Transform transform) 
    {
        
        lineHolder.addLine(transform);
        
           
    
        
    }
    public void removeEnemyData(Transform transform)
    {

        Debug.Log("enemy gone");
        lineHolder.removeLine(transform);

    }
  
}
