using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextSceneName;
    public string mainMenuSceneName;
    private LaserListScript _lls;
    #region Methods
    private void Awake()
    {
        _lls = FindObjectOfType<LaserListScript>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void QuitGame()
    {
        Destroy(_lls.gameObject);
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
    #endregion
}
