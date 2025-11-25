using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePanelController : MonoBehaviour
{
    public CanvasGroup panelCanvas;
    public GameObject backgroundBlocker; // un panel negro con alpha
    public RectTransform panelWindow;

    private bool isOpen = false;

    void Start()
    {
        ClosePanelImmediate();
    }

    // -----------------------------
    // Abrir puzzle
    // -----------------------------
    public void OpenPanel()
    {
        Debug.Log("OpenPanel() ejecutado — panelCanvas.alpha = " + panelCanvas.alpha);

        isOpen = true;
        backgroundBlocker.SetActive(true);

        panelCanvas.alpha = 1;
        panelCanvas.blocksRaycasts = true;
        panelWindow.localScale = Vector3.one;

        Debug.Log("DESPUÉS: panelCanvas.alpha = " + panelCanvas.alpha
            + " | panelWindow.scale = " + panelWindow.localScale);
    }


    // -----------------------------
    // Cerrar puzzle
    // -----------------------------
    public void ClosePanel()
    {
        isOpen = false;

        backgroundBlocker.SetActive(false);
        panelCanvas.alpha = 0;
        panelCanvas.blocksRaycasts = false;

        panelWindow.localScale = Vector3.zero;
    }

    private void ClosePanelImmediate()
    {
        backgroundBlocker.SetActive(false);
        panelCanvas.alpha = 0;
        panelCanvas.blocksRaycasts = false;
        panelWindow.localScale = Vector3.zero;
    }

    // Detectar click fuera del panel
    public void OnBackgroundClick()
    {
        if (isOpen)
        {
            var puzzle = FindFirstObjectByType<Puzzle2_Codigo>();
            puzzle.ClosePuzzle();
        }
    }
}
