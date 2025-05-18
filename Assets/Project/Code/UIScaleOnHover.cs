using UnityEngine;
using UnityEngine.EventSystems;

public class UIScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float hoverScale;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;
    private Vector3 originalScale;

    void OnEnable()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX(hoverClip);
        transform.localScale = hoverScale * originalScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void WinPuzzle(Transform parent)
    {
        AudioManager.Instance.PlaySFX(win);
        PuzzleManager.Instance.WinPuzzle(parent);
    }

    public void LosePuzzle(Transform parent)
    {
        AudioManager.Instance.PlaySFX(lose);
        PuzzleManager.Instance.LosePuzzle(parent);
    }
}
