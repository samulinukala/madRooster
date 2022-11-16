using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private Image Healthbar;
    private int maxHealth;
    private float HealthSections;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = FindObjectOfType<playerMovement>().health;
        Healthbar = GetComponent<Image>();
        HealthSections =(float) 1 / maxHealth;
        Debug.Log(HealthSections);
    }

    // Update is called once per frame
    void Update()
    {
     Healthbar.transform.localScale=new Vector3( FindObjectOfType<playerMovement>().health*HealthSections, Healthbar.transform.localScale.y, 1f);
    }
}
