using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    private void Start()
    {
        pointsText.text = PuzzleManager.Instance.LoseText();
    }

    public void DestroyObject()
    {
        PlayerController.Instance.ChangeState(PlayerState.MOVE);
        Destroy(gameObject);
    }
}
