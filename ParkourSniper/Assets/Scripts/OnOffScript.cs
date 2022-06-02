using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffScript : MonoBehaviour
{
    public Material offMaterial;
    public Material onMaterial;

    public bool isWall;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = offMaterial;
    }
    public void OnMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = onMaterial;
        if (!isWall)
            GetComponent<Collider>().isTrigger = false;
        else
        {
            GetComponent<Collider>().isTrigger = true;
            gameObject.layer = 2;
        }

    }
}
