using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOffOnScript : MonoBehaviour
{
    public Material offMaterial;
    public Material onMaterial;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = offMaterial;
    }
    public void OnMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = onMaterial;
    }
}
