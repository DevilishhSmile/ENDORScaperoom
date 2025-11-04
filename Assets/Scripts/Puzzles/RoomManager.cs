using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleBase> puzzles;
    private int puzzlesCompleted = 0;

    [SerializeField] private string nextSceneName;

    private void Start()
    {
        // Suscribirse al GameManager
        GameManager.Instance.OnPuzzleCompleted += HandlePuzzleCompleted;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPuzzleCompleted -= HandlePuzzleCompleted;
    }

    private void HandlePuzzleCompleted()
    {
        puzzlesCompleted++;

        if (puzzlesCompleted >= puzzles.Count)
        {
            Debug.Log("Todos los puzzles completados!");
            GameManager.Instance.AllPuzzlesCompleted();
            Invoke("GoToNextScene", 1f);
        }
    }

    private void GoToNextScene()
    {
        GameManager.Instance.LoadScene(nextSceneName);
    }
}
