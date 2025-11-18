using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject mainMenu;
    public GameObject hud;
    public GameObject dialoguePanel;
    public GameObject puzzlePanel;
    public GameObject transitionPanel;

    [Header("Dialogue UI")]
    public TMP_Text characterNameText;
    public TMP_Text dialogueText;

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

    // --------------------------------------------
    // Generic panel visibility
    // --------------------------------------------
    public void Show(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Hide(GameObject panel)
    {
        panel.SetActive(false);
    }

    // --------------------------------------------
    // Dialogue
    // --------------------------------------------
    public void ShowDialogue(string character, string text)
    {
        dialoguePanel.SetActive(true);
        characterNameText.text = character;
        dialogueText.text = text;
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    // --------------------------------------------
    // Puzzles
    // --------------------------------------------
    public void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
        hud.SetActive(false);
    }

    public void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);
        hud.SetActive(true);
    }

    // --------------------------------------------
    // Transitions
    // --------------------------------------------
    public void ShowTransition()
    {
        transitionPanel.SetActive(true);
    }

    public void HideTransition()
    {
        transitionPanel.SetActive(false);
    }
}
