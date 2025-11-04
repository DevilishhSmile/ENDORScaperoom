using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

    // Eventos globales
    public Action OnPuzzleStarted;
    public Action OnPuzzleCompleted;
    public Action OnAllPuzzlesCompleted;

    private void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
    }

    public void PuzzleStarted()
    {
        OnPuzzleStarted?.Invoke();
    }

    public void PuzzleCompleted()
    {
        OnPuzzleCompleted?.Invoke();
    }

    public void AllPuzzlesCompleted()
    {
        OnAllPuzzlesCompleted?.Invoke();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
