using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimator : MonoBehaviour
{

    private LineRenderer laser;
    private bool pulsate;
    public float inc_value;
    public float threshold_min;
    public float threshold_max;

    void Start()
    {
        laser = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Time.frameCount % 3 == 0)
        {
            LaserPulse();
        }
    }

    public void LaserPulse()
    {
        if (laser.endWidth <= threshold_min)
        {
            pulsate = true;
        }
        else if (laser.endWidth >= threshold_max)
        {
            pulsate = false;
        }
        if (pulsate)
        {
            laser.endWidth = laser.startWidth += inc_value;
        }
        else
        {
            laser.endWidth = laser.startWidth -= inc_value;
        }
    }
}
