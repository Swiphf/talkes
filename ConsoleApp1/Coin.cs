public class Coin
{
    public Side Side { get; private set; }
    public Coin(Side side)
    {
        this.Side = side;        
    }

    internal void Flip()
    {
        if (this.Side == Side.gold)
        {
            this.Side = Side.silver;
        }
        else
        {
            this.Side = Side.gold;
        }
    }
}

public enum Side
{
    silver,
    gold
}