using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserListScript : MonoBehaviour
{
    [SerializeField]
    public List<LaserData> laserList = new List<LaserData>();

    [SerializeField]
    public List<LaserData> laserListSave = new List<LaserData>();

    

    public void LaserListQueue(Vector3 Dir, Vector3 Origin, float Time)
    {
        laserList.Add(new LaserData(Dir, Origin, Time));
        LaserListSaveQueue(Dir, Origin, Time);
        laserList.Count();
    }
    public void LaserListSaveQueue(Vector3 Dir, Vector3 Origin, float Time)
    {
        laserListSave.Add(new LaserData(Dir, Origin, Time));
    }
    public void QueueReset()
    {
        laserList.Clear();
        foreach(var data in laserListSave)
        {
            laserList.Add(data);
        }
    }
    public void WipeList()
    {
        laserList.Clear();
        laserListSave.Clear();
    }
}
