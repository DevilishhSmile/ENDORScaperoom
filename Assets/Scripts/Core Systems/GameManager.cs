using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public GameState currentState;

    [Header("Puzzle Control - Sala 1")]
    public int puzzlesCompletedSala1 = 0;
    public int totalPuzzlesSala1 = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Cuando inicia el juego por primera vez
        currentState = GameState.MainMenu;
    }

    // ============================================================
    // Inicio desde el menú principal
    // ============================================================
    public void StartGame()
    {
        currentState = GameState.Intro;
        SceneManager.LoadScene("IntroScene");
    }

    // ============================================================
    // Después de la intro → Sala 1
    // ============================================================
    public void StartSala1()
    {
        currentState = GameState.Sala1;
        puzzlesCompletedSala1 = 0;
        SceneManager.LoadScene("Sala1");
    }

    // ============================================================
    // Reportar puzzle completado (Sala 1)
    // ============================================================
    public void PuzzleCompleted()
    {
        puzzlesCompletedSala1++;

        Debug.Log("Puzzle completado. Total: " + puzzlesCompletedSala1);

        if (puzzlesCompletedSala1 >= totalPuzzlesSala1)
        {
            Sala1Completed();
        }
    }

    private void Sala1Completed()
    {
        Debug.Log("SALA 1 COMPLETADA!");

        currentState = GameState.Final;
        SceneManager.LoadScene("FinalScreen");
    }

    // ============================================================
    // Failsafe → volver al menú
    // ============================================================
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        currentState = GameState.MainMenu;
    }
}
