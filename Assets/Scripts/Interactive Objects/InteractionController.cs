using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 3f;

    private InteractableObject currentObject;

    // Referencias a puzzles activos en la escena
    private Puzzle1_Llave puzzle1;
    private Puzzle2_Codigo puzzle2;
    private Puzzle3_Ordenar puzzle3;

    void Start()
    {
        // Buscar puzzles en escena una vez
        puzzle1 = FindFirstObjectByType<Puzzle1_Llave>();
        puzzle2 = FindFirstObjectByType<Puzzle2_Codigo>();
        puzzle3 = FindFirstObjectByType<Puzzle3_Ordenar>();
    }

    void Update()
    {
        DetectObject();

        if (Input.GetMouseButtonDown(0) && currentObject != null)
        {
            Interact(currentObject);
        }
    }

    // ---------------------------------------------------------
    // Detectar objeto con Raycast (2D)
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
    // Interacción por puzzle
    // ---------------------------------------------------------
    void Interact(InteractableObject obj)
    {
        string id = obj.objectID;

        // Puzzle 1
        if (puzzle1 != null)
        {
            puzzle1.OnObjectClicked(id);
        }

        // Puzzle 2
        if (puzzle2 != null)
        {
            puzzle2.OnDigitClicked(id);
        }

        // Puzzle 3
        if (puzzle3 != null)
        {
            puzzle3.OnPaperClicked(id);
        }
    }
}
