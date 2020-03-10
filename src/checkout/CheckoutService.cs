using System.Collections.Generic;

namespace SilpoMarket
{
  public class CheckoutService
  {
    private Check check;
    public void OpenCheck()
    {
      check = new Check();
    }
    public void AddProduct(Product product)
    {
      if (check == null)
      {
        OpenCheck();
      }

      check.AddProduct(product);
    }

    public Check CloseCheck()
    {
      Check closedCheck = check;
      check = null;
      return closedCheck;
    }

    public void UseOffer(Offer offer)
    {
      if (offer.GetType() == typeof(FactorByCategoryOffer))
      {
        FactorByCategoryOffer fbOffer = (FactorByCategoryOffer)offer;
        int points = check.getCostByCategory(fbOffer.category);
        check.AddPoints(points * (fbOffer.factor - 1));
      }
      else
      {
        if (offer.GetType() == typeof(AnyGoodsOffer))
        {
          AnyGoodsOffer agOffer = (AnyGoodsOffer)offer;
          if (agOffer.totalCost <= check.GetTotalCost())
          {
            check.AddPoints(agOffer.points);
          }
        }
      }
    }


  }
}