using UnityEngine;

public class VARSystem : MonoBehaviour
{
    public bool varActive = true;

    public enum Decision
    {
        GoalConfirmed,
        GoalCancelled,
        Offside,
        Foul,
        NoAction
    }

    public Decision currentDecision;


    public void ReviewGoal()
    {
        if (!varActive)
            return;

        Debug.Log("VAR: Revisando o lance...");

        int result = Random.Range(0, 100);

        if (result < 70)
        {
            currentDecision = Decision.GoalConfirmed;
            Debug.Log("VAR: Gol confirmado! ⚽");
        }
        else
        {
            currentDecision = Decision.GoalCancelled;
            Debug.Log("VAR: Gol anulado.");
        }
    }


    public void ReviewOffside()
    {
        if (!varActive)
            return;

        Debug.Log("VAR: Verificando impedimento...");

        bool offside = Random.value > 0.5f;

        if (offside)
        {
            currentDecision = Decision.Offside;
            Debug.Log("VAR: Impedimento confirmado 🚩");
        }
        else
        {
            currentDecision = Decision.NoAction;
            Debug.Log("VAR: Jogada legal.");
        }
    }


    public void ReviewFoul()
    {
        if (!varActive)
            return;

        currentDecision = Decision.Foul;

        Debug.Log("VAR: Falta revisada pelo árbitro.");
    }


    public string GetDecision()
    {
        return currentDecision.ToString();
    }
}
