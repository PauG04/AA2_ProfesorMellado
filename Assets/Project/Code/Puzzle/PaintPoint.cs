using System.Collections.Generic;
using UnityEngine;

public class PaintPoint : MonoBehaviour
{
    public static PaintPoint Instance { get; private set; }

    public List<GameObject> miniPaint;
    public List<GameObject> paint;

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
    private void OnEnable()
    {
        for(int i = 0; i < miniPaint.Count; i++) 
        {
            if (PaintManager.Instance.GetIsActiveMiniPaint(i))
                miniPaint[i].SetActive(true);
            else
                miniPaint[i].SetActive(false);
        }

        for (int i = 0; i < paint.Count; i++)
        {
            if (PaintManager.Instance.GetIsActivePaint(i))
                paint[i].SetActive(true);
            else
                paint[i].SetActive(false);
        }
    }

    public void ActivePaint()
    {
        for (int i = 0; i < miniPaint.Count; i++)
        {
            if (PaintManager.Instance.GetIsActiveMiniPaint(i))
                miniPaint[i].SetActive(true);
            else
                miniPaint[i].SetActive(false);
        }

        for (int i = 0; i < paint.Count; i++)
        {
            if (PaintManager.Instance.GetIsActivePaint(i))
                paint[i].SetActive(true);
            else
                paint[i].SetActive(false);
        }
    }
}
