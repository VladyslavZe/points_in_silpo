namespace SilpoMarket
{
  public class FactorByCategoryOffer : Offer
  {
    public readonly Category category;
    public readonly int factor;
    public FactorByCategoryOffer(Category category, int factor)
    {

      this.category = category;
      this.factor = factor;
    }

    public override void apply(Check check)
    {
      int points = check.getCostByCategory(this.category);
      check.AddPoints(points * (this.factor - 1));
    }
  }
}