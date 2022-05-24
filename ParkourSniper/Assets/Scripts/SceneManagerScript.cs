using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //public List<GameObject> Enemys = new List<GameObject>();
    public LaserListScript lls;


    public bool isLongLvl;

    public Animator animatorDoorEnd;

    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        animatorDoorEnd = GameObject.FindObjectOfType<EndDoorScript>().GetComponent<Animator>();
        //LvlSpace();
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
    //private void Update()
    //{
    //    if(animatorDoorEnd.ge)
    //}
    private void OnLevelWasLoaded(int level)
    {
        animatorDoorEnd = GameObject.FindObjectOfType<EndDoorScript>().GetComponent<Animator>();
    }
    public void StartNextScene()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneName);

        //return null;
    }
    public void RestartScene()
    {
        lls.QueueReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
