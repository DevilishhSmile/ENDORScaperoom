using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public int puzzlesSolved = 0;
    public int totalPuzzles = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PuzzleSolved()
    {
        puzzlesSolved++;
        Debug.Log("Puzzle completado! Total: " + puzzlesSolved);

        if (puzzlesSolved >= totalPuzzles)
        {
            Debug.Log("TODOS LOS PUZZLES COMPLETADOS — AVANZAR A SIGUIENTE SALA");
            GameManager.Instance.StartSala1(); // O siguiente sala
        }
    }
}
