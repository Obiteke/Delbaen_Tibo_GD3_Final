using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    private Animator _animator;
    private SceneManagerScript sMS;

    private void Start()
    {
        sMS = FindObjectOfType<SceneManagerScript>();
        _animator = gameObject.GetComponent<Animator>();
    }
    public void AnimationEnded()
    {
        sMS.StartNextScene();
    }
}
