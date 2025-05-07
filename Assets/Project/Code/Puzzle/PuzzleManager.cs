using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    [SerializeField] private GameObject CanvasWin;
    [SerializeField] private GameObject CanvasLose;

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

    public void WinPuzzle()
    {
        CanvasWin.SetActive(true);
    }

    public void LosePuzzle()
    {
        CanvasLose.SetActive(true);
    }
}
