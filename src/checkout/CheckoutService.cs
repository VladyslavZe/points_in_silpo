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

    public void UseOffer(AnyGoodsOffer anyGoodsOffer)
    {
      if (anyGoodsOffer.GetType() == typeof(FactorByCategoryOffer))
      {
        FactorByCategoryOffer fbOffer = (FactorByCategoryOffer)anyGoodsOffer;
        int points = check.getCostByCategory(fbOffer.category);
        // check.AddPoints(points);
        check.AddPoints(points * (fbOffer.factor - 1));
      }
      else
      {
        if (anyGoodsOffer.totalCost <= check.GetTotalCost())
        {
          check.AddPoints(anyGoodsOffer.points);
        }
      }
    }


  }
}