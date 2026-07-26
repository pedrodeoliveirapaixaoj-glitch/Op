using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public float volume = 1f;
    public bool musicEnabled = true;
    public bool soundEnabled = true;

    public int graphicsQuality = 2;

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

        LoadSettings();
    }

    public void SetVolume(float value)
    {
        volume = value;
        AudioListener.volume = volume;
        SaveSettings();
    }

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;
        SaveSettings();
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        SaveSettings();
    }

    public void SetGraphicsQuality(int quality)
    {
        graphicsQuality = quality;
        QualitySettings.SetQualityLevel(graphicsQuality);
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetInt("Music", musicEnabled ? 1 : 0);
        PlayerPrefs.SetInt("Sound", soundEnabled ? 1 : 0);
        PlayerPrefs.SetInt("Graphics", graphicsQuality);

        PlayerPrefs.Save();

        Debug.Log("Configurações salvas!");
    }

    public void LoadSettings()
    {
        volume = PlayerPrefs.GetFloat("Volume", 1f);
        musicEnabled = PlayerPrefs.GetInt("Music", 1) == 1;
        soundEnabled = PlayerPrefs.GetInt("Sound", 1) == 1;
        graphicsQuality = PlayerPrefs.GetInt("Graphics", 2);

        QualitySettings.SetQualityLevel(graphicsQuality);
        AudioListener.volume = volume;
    }
}
