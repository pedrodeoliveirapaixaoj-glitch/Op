using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource stadiumSource;
    public AudioSource effectsSource;
    public AudioSource commentarySource;


    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float stadiumVolume = 1f;
    public float effectsVolume = 1f;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }


    public void PlayStadiumSound(AudioClip sound)
    {
        stadiumSource.clip = sound;
        stadiumSource.loop = true;
        stadiumSource.Play();
    }


    public void PlayEffect(AudioClip effect)
    {
        effectsSource.PlayOneShot(effect);
    }


    public void PlayCommentary(AudioClip voice)
    {
        commentarySource.PlayOneShot(voice);
    }


    public void SetMasterVolume(float value)
    {
        masterVolume = value;

        AudioListener.volume = masterVolume;
    }


    public void SetMusicVolume(float value)
    {
        musicVolume = value;

        musicSource.volume = musicVolume;
    }


    public void SetStadiumVolume(float value)
    {
        stadiumVolume = value;

        stadiumSource.volume = stadiumVolume;
    }


    public void SetEffectsVolume(float value)
    {
        effectsVolume = value;

        effectsSource.volume = effectsVolume;
    }
}
