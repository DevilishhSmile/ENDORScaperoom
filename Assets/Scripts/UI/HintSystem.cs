using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private float hintCooldown = 10f;
    private bool canGiveHint = true;

    [SerializeField] private string[] hintsSala1;
    [SerializeField] private string[] hintsSala2;
    [SerializeField] private string[] hintsSala3;

    private int index = 0;

    public void RequestHint()
    {
        if (!canGiveHint) return;

        string hint = GetHintForCurrentRoom();
        DialogueManager.Instance.ShowDialogue(hint);

        canGiveHint = false;
        Invoke(nameof(ResetCooldown), hintCooldown);
    }

    private void ResetCooldown()
    {
        canGiveHint = true;
    }

    private string GetHintForCurrentRoom()
    {
        switch (GameManager.Instance.CurrentState)
        {
            case GameState.Sala1:
                return hintsSala1[index++ % hintsSala1.Length];
            case GameState.Sala2:
                return hintsSala2[index++ % hintsSala2.Length];
            case GameState.Sala3:
                return hintsSala3[index++ % hintsSala3.Length];
        }

        return "No hay pistas disponibles.";
    }
}
