using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectID;  // Ej. "llave", "cajon1", "papel2"

    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            originalColor = sr.color;
    }

    public void Highlight(bool active)
    {
        if (sr == null) return;

        sr.color = active ? Color.yellow : originalColor;
    }

    public void Interact()
    {
        // Este método será manejado desde el InteractionController
        Debug.Log("Interacción con objeto: " + objectID);
    }
}
