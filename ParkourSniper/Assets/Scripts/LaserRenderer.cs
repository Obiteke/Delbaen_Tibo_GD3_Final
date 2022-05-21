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
        LaserListScript lls = FindObjectOfType<LaserListScript>();
        resetScene = FindObjectOfType<ResetScene>();

        MeshCollider collider = _lR.gameObject.AddComponent<MeshCollider>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            shot = lls.laserList[0];
            lls.laserList.Remove(shot);
        }
        else
        {
            shot = lls.laserList[lls.laserList.Count - 1];
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

    }
    private void Update()
    {
        RaycastHit hitMovedThrough;

        if (Physics.Linecast(shot.Position, shot.Position + (shot.Direction * _laserRange), out hitMovedThrough))
        {
            if (hitMovedThrough.collider.gameObject.layer == 7)
            {
                Debug.Log("hitBaby");
                resetScene.RestartScene();
            }
        }
    }
}
