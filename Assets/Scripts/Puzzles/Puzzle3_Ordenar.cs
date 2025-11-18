using UnityEngine;
using System.Collections.Generic;

public class Puzzle3_Ordenar : MonoBehaviour
{
    public List<string> correcto = new List<string>() { "p1", "p2", "p3" };

    private List<string> seleccionActual = new List<string>();

    // Método que usa InteractionController
    public void OnPaperClicked(string id)
    {
        Interact(id);
    }

    public void Interact(string objectID)
    {
        if (objectID == "verificar")
        {
            Verificar();
            return;
        }

        if (objectID.StartsWith("p"))
        {
            seleccionActual.Add(objectID);
            Debug.Log("Seleccionado: " + objectID);
        }
    }

    void Verificar()
    {
        if (seleccionActual.Count != correcto.Count)
        {
            Debug.Log("No seleccionaste suficientes papeles.");
            seleccionActual.Clear();
            return;
        }

        for (int i = 0; i < correcto.Count; i++)
        {
            if (seleccionActual[i] != correcto[i])
            {
                Debug.Log("Orden incorrecto!");
                seleccionActual.Clear();
                return;
            }
        }

        Debug.Log("Orden CORRECTO!");

        FindFirstObjectByType<RoomManager>().PuzzleSolved();
    }
}
