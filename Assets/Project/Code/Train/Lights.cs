using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lights : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;

    [SerializeField] private GameObject train1;
    [SerializeField] private AudioClip audio;

    private void Start()
    {
        PlayerController.Instance.ChangeState(PlayerState.PUZZLE);
        PlayerController.Instance.SetDirection();
        Invoke("LightOFF", 2);
    }
    public void LightOFF()
    {
        globalLight.intensity = 0f;
        AudioManager.Instance.PlaySFX(audio);
        Invoke("LightOn", 2);
    }

    public void LightOn()
    {
        globalLight.intensity = 1f;
        train1.SetActive(false);
        PlayerController.Instance.ChangeState(PlayerState.WAIT);
    }
}
