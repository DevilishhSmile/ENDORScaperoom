using UnityEngine;

public class Puzzle1_Llave : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject llave;
    public GameObject cajonCerrado;
    public GameObject cajonAbierto;

    private bool llaveObtenida = false;
    private bool cajonAbiertoFlag = false;

    void Start()
    {
        cajonAbierto.SetActive(false);
    }

    // Este método lo llama InteractionController
    public void OnObjectClicked(string objectID)
    {
        Debug.Log("RECEIVED BY PUZZLE 1: " + objectID);

        if (objectID == "llave" && !llaveObtenida)
        {
            Debug.Log("→ ESTÁS CLICKEANDO LA LLAVE");
            llaveObtenida = true;
            llave.SetActive(false);
            return;
        }

        if (objectID == "cajon")
        {
            Debug.Log("→ ESTÁS CLICKEANDO EL CAJÓN");
        }

        if (objectID == "cajon" && llaveObtenida && !cajonAbiertoFlag)
        {
            Debug.Log("→ CUMPLE CONDICIONES PARA ABRIR EL CAJÓN");

            cajonAbiertoFlag = true;
            cajonCerrado.SetActive(false);
            cajonAbierto.SetActive(true);

            RoomManager.Instance.PuzzleSolved();

            Debug.Log("Cajón abierto!");
        }
    }

}
