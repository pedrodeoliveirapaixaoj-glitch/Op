using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;
    public AudioSource crowdSource;

    public AudioClip menuMusic;
    public AudioClip goalSound;
    public AudioClip kickSound;
    public AudioClip buttonSound;
    public AudioClip crowdSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic(menuMusic);
        PlayCrowd();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null || clip == null)
            return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        if (effectsSource == null || clip == null)
            return;

        effectsSource.PlayOneShot(clip);
    }

    public void PlayGoal()
    {
        PlaySound(goalSound);
        Debug.Log("GOOOOOL!");
    }

    public void PlayKick()
    {
        PlaySound(kickSound);
    }

    public void PlayButton()
    {
        PlaySound(buttonSound);
    }

    public void PlayCrowd()
    {
        if (crowdSource != null && crowdSound != null)
        {
            crowdSource.clip = crowdSound;
            crowdSource.loop = true;
            crowdSource.Play();
        }
    }

    public void StopAllAudio()
    {
        musicSource.Stop();
        effectsSource.Stop();
        crowdSource.Stop();
    }
}
