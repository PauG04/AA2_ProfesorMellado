using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance { get; private set; }
    [SerializeField] private AudioClip openLogros;
    [SerializeField] private AudioClip startGame;
    [SerializeField] private GameObject backButton;

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


    public void LoadSceneByName(string sceneName)
    {
        AudioManager.Instance.PlaySFX(startGame);
        SceneManager.LoadScene(sceneName);
    }

    public void ActiveLogo(GameObject _object)
    {
        AudioManager.Instance.PlaySFX(openLogros);
        backButton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _object.SetActive(true);
    }

    public void DesactiveLogo(GameObject _object)
    {
        AudioManager.Instance.PlaySFX(openLogros);
        _object.SetActive(false);
    }

}
