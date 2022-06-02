using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private SceneManagerScript sMS;
    private void Awake()
    {
        sMS = FindObjectOfType<SceneManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        sMS.RestartScene();
    }
}
