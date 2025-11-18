using UnityEngine;

public class Puzzle2_Codigo : MonoBehaviour
{
    public string correctCode = "1234";
    private string userInput = "";

    public GameObject cajonBloqueado;
    public GameObject cajonAbierto;
    public GameObject papelCodigo;

    void Start()
    {
        cajonAbierto.SetActive(false);
        papelCodigo.SetActive(false);
    }

    // Método que llama InteractionController
    public void OnDigitClicked(string digit)
    {
        AddDigit(digit);
    }

    public void AddDigit(string digit)
    {
        userInput += digit;
        Debug.Log("Input: " + userInput);

        if (userInput.Length == 4)
        {
            CheckCode();
        }
    }

    void CheckCode()
    {
        if (userInput == correctCode)
        {
            Debug.Log("Código correcto!");

            cajonBloqueado.SetActive(false);
            cajonAbierto.SetActive(true);
            papelCodigo.SetActive(true);

            FindFirstObjectByType<RoomManager>().PuzzleSolved();
        }
        else
        {
            Debug.Log("Código incorrecto.");
        }

        userInput = "";
    }
}
