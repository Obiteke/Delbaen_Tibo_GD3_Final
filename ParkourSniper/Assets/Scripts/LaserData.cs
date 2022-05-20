using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserData
{
    public Vector3 Direction;
    public Vector3 Position;
    public float Time;

    public LaserData(Vector3 direction, Vector3 position, float time)
    {
        Direction = direction;
        Position = position;
        Time = time;
    }
}
