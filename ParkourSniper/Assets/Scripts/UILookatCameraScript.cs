using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookatCameraScript : MonoBehaviour
{
    private Camera _cam;
    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        transform.LookAt(_cam.transform);
        transform.Rotate(0, 180, 0);
    }
}
