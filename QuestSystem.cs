using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [System.Serializable]
    public class Quest
    {
        public string title;
        public string description;

        public int target;
        public int progress;

        public int rewardCoins;

        public bool completed;
        public bool daily;
    }


    public List<Quest> quests = new List<Quest>();

    public int coins = 0;


    void Start()
    {
        CreateQuests();
    }


    void CreateQuests()
    {
        // Missões diárias
        quests.Add(new Quest
        {
            title = "Primeira Vitória",
            description = "Vença 1 partida.",
            target = 1,
            rewardCoins = 500,
            daily = true
        });


        quests.Add(new Quest
        {
            title = "Artilheiro do Dia",
            description = "Marque 5 gols.",
            target = 5,
            rewardCoins = 1000,
            daily = true
        });


        // Objetivos da temporada
        quests.Add(new Quest
        {
            title = "Campeão da Temporada",
            description = "Ganhe 20 partidas na temporada.",
            target = 20,
            rewardCoins = 10000,
            daily = false
        });
    }


    public void AddProgress(string questTitle, int amount)
    {
        Quest quest = quests.Find(q => q.title == questTitle);

        if (quest == null || quest.completed)
            return;


        quest.progress += amount;


        if (quest.progress >= quest.target)
        {
            CompleteQuest(quest);
        }
    }


    void CompleteQuest(Quest quest)
    {
        quest.completed = true;

        coins += quest.rewardCoins;


        Debug.Log(
            "Missão concluída: " +
            quest.title +
            " | Recompensa: " +
            quest.rewardCoins +
            " moedas"
        );
    }


    public void ResetDailyQuests()
    {
        foreach (Quest quest in quests)
        {
            if (quest.daily)
            {
                quest.progress = 0;
                quest.completed = false;
            }
        }

        Debug.Log("Missões diárias renovadas!");
    }


    public void ShowQuests()
    {
        foreach (Quest quest in quests)
        {
            Debug.Log(
                quest.title +
                " - " +
                quest.progress +
                "/" +
                quest.target
            );
        }
    }
}
