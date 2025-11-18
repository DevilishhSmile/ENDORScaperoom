using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [TextArea]
    public string[] hints; // Lista de pistas
    private int currentHintIndex = 0;

    public GameObject hintPanel;
    public TMPro.TMP_Text hintText;

    private void Start()
    {
        HideHint();
    }

    public void ShowNextHint()
    {
        // Verificar si estamos en una sala jugable
        if (GameManager.Instance.currentState != GameState.Sala1 &&
            GameManager.Instance.currentState != GameState.Sala2 &&
            GameManager.Instance.currentState != GameState.Sala3)
        {
            Debug.Log("El sistema de pistas no está disponible en este estado.");
            return;
        }

        if (hints.Length == 0)
        {
            Debug.LogWarning("No hay pistas asignadas.");
            return;
        }

        if (currentHintIndex < hints.Length)
        {
            hintPanel.SetActive(true);
            hintText.text = hints[currentHintIndex];
            currentHintIndex++;
        }
        else
        {
            hintText.text = "No hay más pistas disponibles.";
        }
    }

    public void HideHint()
    {
        hintPanel.SetActive(false);
    }
}
