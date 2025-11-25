using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private InteractableObject currentObject;

    // Puzzles en escena
    private Puzzle1_Llave puzzle1;
    private Puzzle2_Codigo puzzle2;
    private Puzzle3_Ordenar puzzle3;

    void Start()
    {
        puzzle1 = FindFirstObjectByType<Puzzle1_Llave>();
        puzzle2 = FindFirstObjectByType<Puzzle2_Codigo>();
        puzzle3 = FindFirstObjectByType<Puzzle3_Ordenar>();
    }

    void Update()
    {
        // 🚫 NO dejar interactuar con el mundo si el puzzle de código está abierto
        if (puzzle2 != null && puzzle2.puzzleActive)
            return;

        DetectObject();

        if (Input.GetMouseButtonDown(0) && currentObject != null)
        {
            Interact(currentObject);
        }
    }

    // ---------------------------------------------------------
    // Raycast 2D para detectar objetos clickeables
    // ---------------------------------------------------------
    void DetectObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            var interactObj = hit.collider.GetComponent<InteractableObject>();
            if (interactObj != null)
            {
                currentObject = interactObj;
                return;
            }
        }

        currentObject = null;
    }

    // ---------------------------------------------------------
    // Lógica de interacción del mundo
    // ---------------------------------------------------------
    void Interact(InteractableObject obj)
    {
        string id = obj.objectID;
        Debug.Log("CLICK DETECTADO: " + id);

        // 👉 Si es el panel pequeño del puzzle de código → abrir puzzle UI
        if (puzzle2 != null && id == "panelCodigo")
        {
            puzzle2.OpenPuzzle();
            return;
        }

        // Puzzle 1 — llave y cajón
        if (puzzle1 != null)
        {
            puzzle1.OnObjectClicked(id);
        }

        // Puzzle 3 — papeles y botón verificar
        if (puzzle3 != null)
        {
            puzzle3.OnPaperClicked(id);
        }
    }
}
