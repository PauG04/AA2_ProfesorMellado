using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip mysteryMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(mysteryMusic);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PlayMysteryMusic()
    {
        PlayMusic(mysteryMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic(float fadeOutTime = 1f)
    {
        StartCoroutine(FadeOutMusic(fadeOutTime));
    }

    public void PlaySFX(AudioClip clip, float pitch = 1)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(clip);
    }

    private System.Collections.IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
