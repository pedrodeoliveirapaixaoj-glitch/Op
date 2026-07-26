using UnityEngine;

public class SettingsSystem : MonoBehaviour
{
    public float musicVolume = 1f;
    public float soundVolume = 1f;

    public string language = "Português";

    public int graphicsQuality = 2;


    public void SetMusicVolume(float value)
    {
        musicVolume = value;

        Debug.Log(
            "Volume da música: " + musicVolume
        );
    }


    public void SetSoundVolume(float value)
    {
        soundVolume = value;

        Debug.Log(
            "Volume dos efeitos: " + soundVolume
        );
    }


    public void ChangeLanguage(string newLanguage)
    {
        language = newLanguage;

        Debug.Log(
            "Idioma alterado para: " +
            language
        );
    }


    public void SetGraphicsQuality(int quality)
    {
        graphicsQuality = quality;

        QualitySettings.SetQualityLevel(
            graphicsQuality
        );

        Debug.Log(
            "Qualidade gráfica alterada."
        );
    }


    public void ResetSettings()
    {
        musicVolume = 1f;
        soundVolume = 1f;
        language = "Português";
        graphicsQuality = 2;

        Debug.Log(
            "Configurações restauradas."
        );
    }
}
