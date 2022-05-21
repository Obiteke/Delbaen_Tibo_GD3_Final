using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserRenderer : MonoBehaviour
{
    private LineRenderer _lR;
    private Camera _cam;

    private List<LaserData> laserList;
    private LaserData shot;
    public ResetScene resetScene;
    private float _laserRange = 300;

    void Start()
    {
        _cam = FindObjectOfType<Camera>().GetComponent<Camera>();
        _lR = GetComponent<LineRenderer>();
        laserList = FindObjectOfType<LaserListScript>().laserList;
        resetScene = FindObjectOfType<ResetScene>();

        MeshCollider collider = _lR.gameObject.AddComponent<MeshCollider>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            shot = laserList[0];
            laserList.Remove(shot);
        }
        else
        {
            shot = laserList[laserList.Count - 1];
        }

        RaycastHit hit;
        if (Physics.Raycast(shot.Position, shot.Direction, out hit))
        {
            if (hit.rigidbody)
            {
                GameObject hitbody = hit.rigidbody.gameObject;
                hitbody.GetComponent<EnemysScript>().Explosion();
                Destroy(hitbody);
            }
        }
        Vector3 cameraOffset = new Vector3(0f, 0.1f, 0f);
        _lR.SetPosition(0, shot.Position - cameraOffset);
        _lR.SetPosition(1, shot.Position + (shot.Direction * _laserRange));

        
        Mesh mesh = new Mesh();
        _lR.BakeMesh(mesh, _cam,true);

        collider.sharedMesh = mesh;
        collider.convex = true;
        collider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("hitBaby");
            resetScene.RestartScene();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("hh");
    //    if (other.gameObject.layer == 7)
    //    {
    //        Debug.Log("hitBaby");
    //        sceneReset.ResetScene();
    //    }
    //}

    
}
