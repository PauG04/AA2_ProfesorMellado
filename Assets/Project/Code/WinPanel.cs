using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI streakText;

    private void Start()
    {
        pointsText.text = PuzzleManager.Instance.GetCurrentPuzzlePoints().ToString();
        streakText.text = "x" + PuzzleManager.Instance.streak.ToString();
    }

    public void DestroyParent()
    {
        PlayerController.Instance.ChangeState(PlayerState.MOVE);
        Destroy(transform.parent.gameObject);
    }
}
