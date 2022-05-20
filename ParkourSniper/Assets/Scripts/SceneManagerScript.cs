using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public List<GameObject> Enemys = new List<GameObject>();
    public LaserListScript lls;

    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        lls = FindObjectOfType<LaserListScript>();
        LaserListScript.DontDestroyOnLoad(lls);
    }
    public void CheckCount()
    {
        if (Enemys.Count == 0)
        {
            StartCoroutine(NextScene());
        }
    }
    //private void OnDestroy()
    //{
    //    
    //}
    private IEnumerator NextScene()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName);

        //return null;
    }
    
}
