using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    public int coins = 0;
    public int trophies = 0;
    public string teamName = "Meu Time";

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

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Trophies", trophies);
        PlayerPrefs.SetString("TeamName", teamName);

        PlayerPrefs.Save();

        Debug.Log("Jogo salvo com sucesso!");
    }

    public void LoadGame()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        trophies = PlayerPrefs.GetInt("Trophies", 0);
        teamName = PlayerPrefs.GetString("TeamName", "Meu Time");

        Debug.Log("Jogo carregado!");
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveGame();
    }

    public void AddTrophies(int amount)
    {
        trophies += amount;
        SaveGame();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();

        coins = 0;
        trophies = 0;
        teamName = "Meu Time";

        Debug.Log("Save apagado!");
    }
}
