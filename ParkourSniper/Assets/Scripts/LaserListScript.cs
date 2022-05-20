using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserListScript : MonoBehaviour
{
    [SerializeField]
    public List<LaserData> laserQueue = new List<LaserData>();

    [SerializeField]
    public List<LaserData> laserQueueSave = new List<LaserData>();



    public void LaserListQueue(Vector3 Dir, Vector3 Origin, float Time)
    {
        laserQueue.Add(new LaserData(Dir, Origin, Time));
        LaserListSaveQueue(Dir, Origin, Time);
    }
    public void LaserListSaveQueue(Vector3 Dir, Vector3 Origin, float Time)
    {
        laserQueueSave.Add(new LaserData(Dir, Origin, Time));
    }
    public void QueueReset()
    {
        laserQueue.Clear();
        foreach(var data in laserQueueSave)
        {
            laserQueue.Add(data);
        }
    }
}
