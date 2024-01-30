using System.Collections;

public abstract class State
{
    protected GameManager GameManager;

    public State(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Draw()
    {
        yield break;
    }

    public virtual IEnumerator Dice()
    {
        yield break;
    }

    public virtual IEnumerator ReRoll()
    {
        yield break;
    }

    public virtual IEnumerator PlaceCards()
    {
        yield break;
    }

    public virtual IEnumerator FightFase()
    {
        yield break;
    }

    public virtual IEnumerator EndTurn()
    {
        yield break;
    }
}