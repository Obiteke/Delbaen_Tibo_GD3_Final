using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    private Animator _animator;
    private SceneManagerScript sMS;

    public bool isSniperLVL;
    //private bool _characterFinished = false;

    private void Start()
    {
        sMS = FindObjectOfType<SceneManagerScript>();
        sMS.isSniperLevel = isSniperLVL;
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
        sMS.lls.WipeList();
        sMS.StartNextScene();
    }
}
