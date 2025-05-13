using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    //[SerializeField] private GameObject CanvasWin;
    //[SerializeField] private GameObject CanvasLose;

    public int puzzlesCompleted;
    public int points;
    public int streak;

    public List<(int maxPoints, int currentPoints)> puzzlePoints;

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

        for (int i = 0; i < puzzlePoints.Count; i++)
        {
            var points = puzzlePoints[i];
            points.currentPoints = points.maxPoints;
            puzzlePoints[i] = points;
        }
    }

    public void WinPuzzle(int puzzleIterator)
    {
        points += puzzlePoints[puzzleIterator].currentPoints;
        streak++;
        puzzlesCompleted++;
        //CanvasWin.SetActive(true);
    }

    public void LosePuzzle(int puzzleIterator)
    {
        streak = 0;
        (int maxPoints, int currentPoints) points = puzzlePoints[puzzleIterator];
        points.currentPoints -= 5;
        puzzlePoints[puzzleIterator] = points;
        //CanvasLose.SetActive(true);
    }
}
