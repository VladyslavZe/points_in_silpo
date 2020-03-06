using System;
using System.Collections.Generic;

namespace SilpoMarket
{
  public class CheckoutService
  {
    private Check check;
    public void openCheck()
    {
      check = new Check();
      check.products = new List<Product>();
      check.totalCost = 0;

    }
    public void addProduct(Product product)
    {
      check.products.Add(product);
    }

    public Check closeCheck()
    {
      foreach (Product product in check.products)
      {
        check.totalCost += product.price;
      }
      return check;

    }

  }
}