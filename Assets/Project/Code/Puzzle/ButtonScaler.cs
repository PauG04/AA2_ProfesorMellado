using UnityEngine;

public class ButtonScaler : MonoBehaviour
{
    Vector3 originalScale;
    [SerializeField] private float scaleMultiplier;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void ScaleUp()
    {
        transform.localScale = originalScale * scaleMultiplier;
    }

    public void ScaleDown()
    {
        transform.localScale = originalScale;
    }
}
