using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lights : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;

    [SerializeField] private GameObject train1;
    [SerializeField] private GameObject train2;

    private void Start()
    {
        PlayerController.Instance.ChangeState(PlayerState.PUZZLE);
        PlayerController.Instance.SetDirection();
        Invoke("LightOFF", 2);
    }
    public void LightOFF()
    {
        globalLight.intensity = 0f;
        Invoke("LightOn", 1);
    }

    public void LightOn()
    {
        globalLight.intensity = 1f;
        train1.SetActive(false);
        train2.SetActive(true);
        PlayerController.Instance.ChangeState(PlayerState.WAIT);
    }
}
