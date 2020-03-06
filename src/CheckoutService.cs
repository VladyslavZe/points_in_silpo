using System;
using System.Collections.Generic;

namespace SilpoMarket
{
  public class CheckoutService
  {
    private Check check;
    public void OpenCheck()
    {
      check = new Check();
      check.products = new List<Product>();
    }
    public void AddProduct(Product product)
    {
      check.products.Add(product);
    }

    public Check CloseCheck()
    {
      foreach (Product product in check.products)
      {
        check.totalCost += product.price;
      }
      return check;

    }

  }
}