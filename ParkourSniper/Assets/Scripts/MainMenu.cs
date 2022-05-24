using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextSceneName;

    #region Methods
    public void PlayGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
