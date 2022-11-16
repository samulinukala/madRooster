using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    public Color levelColor;
    public SpriteRenderer spriteRenderer;
    public Camera Camera;
    public float currentHue;
    public float currentSaturation;
    public float currentBrightness;
    public float changeSpeed=15f;
    // Start is called before the first frame update
    void Start()
    {
        Color.RGBToHSV(levelColor,out currentHue,out currentSaturation,out currentBrightness);
    }

    // Update is called once per frame
    void Update()
    {
        currentHue = currentHue+Time.deltaTime/changeSpeed;
        levelColor= Color.HSVToRGB(currentHue, currentSaturation, currentBrightness);
        if (currentHue > 1)
        {
            currentHue = 0;
        }
        spriteRenderer.color = levelColor;
        Camera.backgroundColor = levelColor;
    }
}
