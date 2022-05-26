using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //public List<GameObject> Enemys = new List<GameObject>();
    public LaserListScript lls;


    public bool isLongLvl;
    public bool isSniperLevel;

    public Animator animatorDoorEnd;

    private NextSceneNameScript _nSNS;
    //public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        _nSNS = GameObject.FindObjectOfType<NextSceneNameScript>();

        if(GameObject.FindObjectOfType<EndDoorScript>() != null)
            animatorDoorEnd = GameObject.FindObjectOfType<EndDoorScript>().GetComponent<Animator>();

        lls = FindObjectOfType<LaserListScript>();
        LaserListScript.DontDestroyOnLoad(lls);
    }
    public void LvlSpace()
    {
        if (isLongLvl)
        {
            animatorDoorEnd.SetBool("LongLVL", true);
        }
        else
        {
            animatorDoorEnd.SetBool("MediumLVL", true);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        _nSNS = GameObject.FindObjectOfType<NextSceneNameScript>();
        animatorDoorEnd = GameObject.FindObjectOfType<EndDoorScript>().GetComponent<Animator>();
    }
    public void StartNextScene()
    {
        SceneManager.LoadScene(_nSNS.nextSceneName);
    }

    public void StartPreviousScene()
    {
        SceneManager.LoadScene(_nSNS.previousSceneName);
    }
    public void RestartScene()
    {
        lls.QueueReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
