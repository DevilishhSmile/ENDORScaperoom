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
        // recoger llave
        if (objectID == "llave" && !llaveObtenida)
        {
            llaveObtenida = true;
            llave.SetActive(false);

            Debug.Log("Llave obtenida!");
            return;
        }

        // abrir cajón
        if (objectID == "cajon" && llaveObtenida && !cajonAbiertoFlag)
        {
            cajonAbiertoFlag = true;

            cajonCerrado.SetActive(false);
            cajonAbierto.SetActive(true);

            Debug.Log("Cajón abierto!");

            // registrar puzzle completado
            RoomManager.Instance.PuzzleSolved();
        }
    }
}
