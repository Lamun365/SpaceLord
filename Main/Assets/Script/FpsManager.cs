using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FpsManager : MonoBehaviour
{
    public Text fpsTxt;
    private int frameCount;
    private float deltaTime;
    private double fps;
    private float UpdateRate = 2.0f;

    private void Start()
    {

    }
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        frameCount++;
        deltaTime += Time.deltaTime;
        if(deltaTime > 1 / UpdateRate)
        {
            fps = Math.Round(frameCount / deltaTime, 1);
            fpsTxt.text = fps.ToString() + " FPS";
            frameCount = 0;
            deltaTime -= 1 / UpdateRate;
        }
    }
}
