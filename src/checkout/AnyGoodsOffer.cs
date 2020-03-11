namespace SilpoMarket
{
  public class AnyGoodsOffer : Offer
  {
    public readonly int totalCost;
    public readonly int points;
    public AnyGoodsOffer(int totalCost, int points)
    {
      this.totalCost = totalCost;
      this.points = points;
    }

    public override void apply(Check check)
    {
      if (check.GetTotalCost() >= this.totalCost)
      {
        check.AddPoints(this.points);
      }
    }
  }
}