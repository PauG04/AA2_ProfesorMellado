using TMPro;
using UnityEngine;

public class PuzzlePointsText : MonoBehaviour
{
    public TextMeshProUGUI puzzlesCompleted;
    public TextMeshProUGUI points;
    public TextMeshProUGUI streak;

    private void OnEnable()
    {
        puzzlesCompleted.text = PuzzleManager.Instance.puzzlesCompleted.ToString();
        points.text = PuzzleManager.Instance.points.ToString();
        streak.text = "x" + PuzzleManager.Instance.streak.ToString();
    }
}
