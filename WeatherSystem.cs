using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public enum WeatherType
    {
        Sunny,
        Rain,
        Snow,
        Wind
    }

    public WeatherType currentWeather = WeatherType.Sunny;

    public ParticleSystem rainEffect;
    public ParticleSystem snowEffect;

    public float ballControlMultiplier = 1f;

    void Start()
    {
        ApplyWeather(currentWeather);
    }

    public void ChangeWeather(WeatherType weather)
    {
        currentWeather = weather;

        ApplyWeather(weather);
    }

    void ApplyWeather(WeatherType weather)
    {
        StopEffects();

        switch (weather)
        {
            case WeatherType.Sunny:
                ballControlMultiplier = 1f;
                Debug.Log("Clima: Ensolarado ☀️");
                break;

            case WeatherType.Rain:
                ballControlMultiplier = 0.85f;

                if (rainEffect != null)
                    rainEffect.Play();

                Debug.Log("Clima: Chuva 🌧️");
                break;

            case WeatherType.Snow:
                ballControlMultiplier = 0.75f;

                if (snowEffect != null)
                    snowEffect.Play();

                Debug.Log("Clima: Neve ❄️");
                break;

            case WeatherType.Wind:
                ballControlMultiplier = 0.9f;

                Debug.Log("Clima: Vento forte 💨");
                break;
        }
    }

    void StopEffects()
    {
        if (rainEffect != null)
            rainEffect.Stop();

        if (snowEffect != null)
            snowEffect.Stop();
    }

    public float GetBallControl()
    {
        return ballControlMultiplier;
    }
}
