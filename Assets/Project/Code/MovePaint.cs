using UnityEngine;

public class MovePaint : MonoBehaviour
{
    [SerializeField] private int id;
    private void OnMouseDown()
    {
        PaintManager.Instance.ActivePaint(id);
        PaintPoint.Instance.ActivePaint();
    }
}
