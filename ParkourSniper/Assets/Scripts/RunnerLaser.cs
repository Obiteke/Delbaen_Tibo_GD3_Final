using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunnerLaser : MonoBehaviour
{
    private float currentTime;
    private List<LaserData> laserQueue;
    private bool hasShotFired = true;
    private LaserData shot;

    public GameObject laser;

    private void Start()
    {
        laserQueue = FindObjectOfType<LaserListScript>().laserList;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (laserQueue.Count != 0)
        {
            if (hasShotFired)
            {
                shot = laserQueue[0];
                hasShotFired = false;

            }
            if (currentTime >= shot.Time)
            {
                Instantiate(laser);
                hasShotFired = true;
            }
        }
    }
}
