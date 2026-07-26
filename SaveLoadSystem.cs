using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public string coachName;

        public string clubName;

        public int season;

        public int trophies;

        public int coins;

        public int wins;

        public int losses;

        public int teamRating;
    }


    public SaveData currentData = new SaveData();


    string savePath;


    void Awake()
    {
        savePath = Application.persistentDataPath + "/Football2026Save.json";
    }


    public void SaveGame()
    {
        string json = JsonUtility.ToJson(currentData, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Carreira salva com sucesso!");
    }


    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            currentData = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Save carregado!");
        }
        else
        {
            Debug.Log("Nenhum save encontrado.");
        }
    }


    public void NewCareer(string coach, string club)
    {
        currentData.coachName = coach;
        currentData.clubName = club;

        currentData.season = 1;
        currentData.trophies = 0;
        currentData.coins = 5000;
        currentData.wins = 0;
        currentData.losses = 0;
        currentData.teamRating = 60;


        SaveGame();
    }


    public void AddWin()
    {
        currentData.wins++;
        currentData.coins += 500;

        SaveGame();
    }


    public void AddTrophy()
    {
        currentData.trophies++;

        SaveGame();
    }
}
