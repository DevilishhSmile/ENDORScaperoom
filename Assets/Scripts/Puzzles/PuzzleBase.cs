using UnityEngine;

public abstract class PuzzleBase : MonoBehaviour
{
    protected bool isCompleted = false;

    public virtual void CompletePuzzle()
    {
        if (isCompleted) return;

        isCompleted = true;
        GameManager.Instance.PuzzleCompleted();
    }
}
