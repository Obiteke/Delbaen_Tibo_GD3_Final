using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    private Animator _animator;
    private SceneManagerScript sMS;

    public bool isSniperLVL = true;
    //private bool _characterFinished = false;

    private void Start()
    {
        sMS = FindObjectOfType<SceneManagerScript>();
        _animator = gameObject.GetComponent<Animator>();
    }
    public void AnimationEnded()
    {
        if (isSniperLVL)
            sMS.StartNextScene();
        else
            sMS.RestartScene();
    }
    private void OnTriggerEnter(Collider other)
    {
        sMS.StartNextScene();
    }
}
