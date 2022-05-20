using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    public LaserListScript lls;
    // Start is called before the first frame update
    void Start()
    {

        lls = FindObjectOfType<LaserListScript>();
    }
    public void RestartScene()
    {
        lls.QueueReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
