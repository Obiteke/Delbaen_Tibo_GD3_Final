using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void TimeScale()
    {
        Time.timeScale = 1;
    }
}
