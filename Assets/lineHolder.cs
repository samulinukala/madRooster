using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lineHolder : MonoBehaviour
{
    public GameObject linePrfab;
    public List<lineData> lines = new List<lineData>();
    public void addLine(Transform _enemyTransform)
    {
        Debug.Log("new line");
        lineData tmp=new();
        tmp.addlineData(Instantiate(linePrfab), _enemyTransform);
        lines.Add(tmp);
    }
    public void removeLine(Transform _enemy)
    {
        lines.ForEach(e =>
            {
               
                if (e.EnemyTransform == _enemy) { Destroy(e); lines.Remove(e); }
            });
    }
    public void updateLines()
    {
        lines.ForEach(e => e.updateLine());
    }
    


   
   
}

