using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintManager : MonoBehaviour
{
    public static PaintManager Instance { get; private set; }

    public List<bool> miniPaint;
    public List<bool> paint;

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

        miniPaint = new List<bool>();
        paint = new List<bool>();

        for (int i = 0; i < 3; i++)
        {
            miniPaint.Add(false);
            paint.Add(false);
        }
    }

    public void ResetPaint()
    {
        miniPaint = new List<bool>();
        paint = new List<bool>();

        for (int i = 0; i < 3; i++)
        {
            miniPaint.Add(false);
            paint.Add(false);
        }
    }

    public void ActiveMiniPaint(int id)
    {
        miniPaint[id] = true;
    }

    public void ActivePaint(int id)
    {
        paint[id] = true;
        miniPaint[id] = false;

        if (AllPaintActive())
            Invoke("GoMainMenu", 5);
    }

    private void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private bool AllPaintActive()
    {
        for (int i = 0; i < paint.Count; i++)
        {
            if (!paint[i])
                return false;
        }
        return true;
    }

    public bool GetIsActiveMiniPaint(int id = 0)
    {
        return miniPaint[id];
    }

    public bool GetIsActivePaint(int id = 0)
    {
        return paint[id];
    }
}
