using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    [System.Serializable]
    public class Achievement
    {
        public string title;
        public string description;
        public bool unlocked;
    }

    public List<Achievement> achievements = new List<Achievement>();

    public int championshipsWon = 0;
    public int goalsScored = 0;
    public int recordsBroken = 0;


    void Start()
    {
        CreateAchievements();
    }


    void CreateAchievements()
    {
        achievements.Add(new Achievement
        {
            title = "Primeiro Troféu",
            description = "Ganhe seu primeiro campeonato.",
            unlocked = false
        });

        achievements.Add(new Achievement
        {
            title = "Artilheiro",
            description = "Marque 100 gols.",
            unlocked = false
        });

        achievements.Add(new Achievement
        {
            title = "Lenda do Futebol",
            description = "Quebre 10 recordes.",
            unlocked = false
        });
    }


    public void WinChampionship()
    {
        championshipsWon++;

        CheckAchievements();

        Debug.Log("Campeonato conquistado!");
    }


    public void ScoreGoal()
    {
        goalsScored++;

        CheckAchievements();

        Debug.Log("Gol marcado!");
    }


    public void BreakRecord()
    {
        recordsBroken++;

        CheckAchievements();

        Debug.Log("Novo recorde!");
    }


    void CheckAchievements()
    {
        if (championshipsWon >= 1)
            UnlockAchievement(0);

        if (goalsScored >= 100)
            UnlockAchievement(1);

        if (recordsBroken >= 10)
            UnlockAchievement(2);
    }


    void UnlockAchievement(int index)
    {
        if (!achievements[index].unlocked)
        {
            achievements[index].unlocked = true;

            Debug.Log(
                "Conquista desbloqueada: " +
                achievements[index].title
            );
        }
    }


    public void ShowAchievements()
    {
        foreach (Achievement achievement in achievements)
        {
            Debug.Log(
                achievement.title +
                " - " +
                (achievement.unlocked ? "Desbloqueada" : "Bloqueada")
            );
        }
    }
}
