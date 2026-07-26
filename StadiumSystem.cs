using UnityEngine;

public class StadiumSystem : MonoBehaviour
{
    [System.Serializable]
    public class Stadium
    {
        public string stadiumName;
        public int capacity;
        public bool nightMode;
    }

    public Stadium currentStadium;

    public GameObject crowd;
    public Light stadiumLight;

    public int crowdIntensity = 100;

    void Start()
    {
        CreateDefaultStadium();
        UpdateStadium();
    }

    void CreateDefaultStadium()
    {
        currentStadium = new Stadium();

        currentStadium.stadiumName = "Football Arena";
        currentStadium.capacity = 50000;
        currentStadium.nightMode = false;
    }

    public void ChangeStadium(string name, int capacity)
    {
        currentStadium.stadiumName = name;
        currentStadium.capacity = capacity;

        Debug.Log("Estádio alterado: " + name);

        UpdateStadium();
    }

    public void SetNightMode(bool night)
    {
        currentStadium.nightMode = night;

        if (stadiumLight != null)
        {
            stadiumLight.enabled = night;
        }

        Debug.Log(night ? "Jogo noturno 🌙" : "Jogo de dia ☀️");
    }

    public void UpdateCrowd(int intensity)
    {
        crowdIntensity = intensity;

        Debug.Log("Torcida: " + intensity + "% de animação");
    }

    public void PlayCrowdSound()
    {
        Debug.Log("Torcida cantando e comemorando! 📣");
    }

    void UpdateStadium()
    {
        Debug.Log(
            "Estádio: " +
            currentStadium.stadiumName +
            " | Capacidade: " +
            currentStadium.capacity
        );
    }
}
