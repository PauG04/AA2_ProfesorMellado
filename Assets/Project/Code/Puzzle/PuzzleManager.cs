using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    [SerializeField] private GameObject CanvasWin;
    [SerializeField] private GameObject CanvasLose;

    [HideInInspector] public int puzzlesCompleted;
    [HideInInspector] public int points;
    [HideInInspector] public int streak;
    [HideInInspector] public int currentPuzzle;

    public List<int> maxPoints;
    public List<int> puzzlePoints;
    public List<bool> puzzleCompleted;

    public int currentId;

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

        DontDestroyOnLoad(gameObject);

        puzzlesCompleted = 0;
        points = 0;
        streak = 0;
        currentPuzzle = 0;

        foreach (int puzzle in maxPoints)
        {
            puzzlePoints.Add(puzzle);
            puzzleCompleted.Add(false);
        }
    }

    public void ResetPuzzle()
    {
        puzzlePoints.Clear();
        puzzleCompleted.Clear();

        puzzlesCompleted = 0;
        points = 0;
        streak = 0;
        currentPuzzle = 0;

        foreach (int puzzle in maxPoints)
        {
            puzzlePoints.Add(puzzle);
            puzzleCompleted.Add(false);
        }
    }

    public void WinPuzzle(Transform parent, int id)
    {
        puzzleCompleted[id] = true;
        currentId = id;
        streak++;
        points += puzzlePoints[id] * streak;
        puzzlesCompleted++;
        Instantiate(CanvasWin, parent);
    }

    public void LosePuzzle(Transform parent)
    {
        streak = 0;
        if (puzzlePoints[currentPuzzle] > maxPoints[currentPuzzle] - 15)
            puzzlePoints[currentPuzzle] -= 5;
        Instantiate(CanvasLose, parent);
    }

    public string LoseText()
    {
        return puzzlePoints[currentPuzzle].ToString() + "/" + maxPoints[currentPuzzle].ToString();
    }

    public int GetCurrentPuzzlePoints()
    {
        return puzzlePoints[currentId];
    }

    public bool GetCurrentPuzzleIsCompleted(int id)
    {
        return puzzleCompleted[id];
    }

}
