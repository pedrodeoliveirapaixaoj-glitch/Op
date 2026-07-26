using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public enum Formation
    {
        F433,
        F442,
        F352,
        F4231
    }

    public Formation currentFormation = Formation.F433;

    public Transform[] playerPositions;

    public void SetFormation(Formation formation)
    {
        currentFormation = formation;

        switch (formation)
        {
            case Formation.F433:
                Debug.Log("Formação alterada para 4-3-3");
                break;

            case Formation.F442:
                Debug.Log("Formação alterada para 4-4-2");
                break;

            case Formation.F352:
                Debug.Log("Formação alterada para 3-5-2");
                break;

            case Formation.F4231:
                Debug.Log("Formação alterada para 4-2-3-1");
                break;
        }

        UpdatePlayerPositions();
    }

    void UpdatePlayerPositions()
    {
        Debug.Log("Reposicionando jogadores...");

        for (int i = 0; i < playerPositions.Length; i++)
        {
            Debug.Log("Jogador " + (i + 1) + " posicionado.");
        }
    }

    public string GetFormationName()
    {
        switch (currentFormation)
        {
            case Formation.F433:
                return "4-3-3";
            case Formation.F442:
                return "4-4-2";
            case Formation.F352:
                return "3-5-2";
            case Formation.F4231:
                return "4-2-3-1";
        }

        return "Desconhecida";
    }
}
