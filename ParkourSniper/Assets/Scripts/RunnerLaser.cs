using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunnerLaser : MonoBehaviour
{
    private float currentTime;
    private List<LaserData> laserList;
    private bool hasShotFired = true;
    private LaserData shot;
    private SceneManagerScript sMS;

    public GameObject laser;

    private void Start()
    {
        laserList = FindObjectOfType<LaserListScript>().laserList;

        sMS = FindObjectOfType<SceneManagerScript>();
        sMS.LvlSpace();
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (laserList.Count != 0)
        {
            if (hasShotFired)
            {
                shot = laserList[0];
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
