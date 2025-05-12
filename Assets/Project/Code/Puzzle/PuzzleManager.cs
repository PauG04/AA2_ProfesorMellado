using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    //[SerializeField] private GameObject CanvasWin;
    //[SerializeField] private GameObject CanvasLose;

    public int puzzlesCompleted;
    public int points;
    public int streak;


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

        puzzlesCompleted = 0;
        points = 0;
        streak = 0;
    }

    public void WinPuzzle(int puzzlePoints)
    {
        points += puzzlePoints;
        streak++;
        puzzlesCompleted++;
        //CanvasWin.SetActive(true);
    }

    public void LosePuzzle()
    {
        streak = 0;
        //CanvasLose.SetActive(true);
    }
}
