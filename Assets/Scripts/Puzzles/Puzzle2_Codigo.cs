using UnityEngine;

public class Puzzle2_Codigo : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public string correctCode = "1234";
    private string userInput = "";
    public bool puzzleActive = false;

    [Header("References in world")]
    public GameObject cajonBloqueado;
    public GameObject cajonAbierto;
    public GameObject papelCodigo;

    [Header("UI Panel")]
    public PuzzlePanelController puzzleUI;

    void Start()
    {
        cajonAbierto.SetActive(false);
        papelCodigo.SetActive(false);
    }

    // Llamado desde InteractionController cuando clicas el panel pequeño
    public void OpenPuzzle()
    {
        if (puzzleActive) return; // evitar doble apertura

       

        if (puzzleUI != null)
            Debug.Log("ABRIENDO PUZZLE 2");
        puzzleActive = true;
        puzzleUI.OpenPanel();
    }

    public void ClosePuzzle()
    {
        puzzleActive = false;

        if (puzzleUI != null)
            puzzleUI.ClosePanel();
    }

    // Llamado solo desde UI (botones del panel grande)
    public void AddDigit(string digit)
    {
        if (!puzzleActive) return;

        userInput += digit;
        Debug.Log("Input: " + userInput);

        if (userInput.Length == 4)
            CheckCode();
    }

    void CheckCode()
    {
        if (userInput == correctCode)
        {
            Debug.Log("Código correcto!");

            cajonBloqueado.SetActive(false);
            cajonAbierto.SetActive(true);
            papelCodigo.SetActive(true);

            if (RoomManager.Instance != null)
                RoomManager.Instance.PuzzleSolved();

            ClosePuzzle();
        }
        else
        {
            Debug.Log("Código incorrecto.");
        }

        userInput = "";
    }
}
