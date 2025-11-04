using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string introSceneName = "IntroScene";

    public void StartGame()
    {
        SceneManager.LoadScene(introSceneName);
    }

    public void OpenCredits()
    {
        // Esto puede ser un panel UI
        UIManager.Instance.ShowCredits();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
