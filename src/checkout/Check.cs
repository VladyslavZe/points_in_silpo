using System;
using System.Collections.Generic;

namespace SilpoMarket
{
  public class Check
  {
    private List<Product> products = new List<Product>();
    private int points = 0;
    public int GetTotalCost()
    {
      int totalCost = 0;
      foreach (Product product in this.products)
      {
        totalCost += product.price;
      }
      return totalCost;
    }
    protected internal void AddProduct(Product product)
    {
      products.Add(product);
    }

    public int GetTotalPoints()
    {
      return GetTotalCost() + this.points;
    }

    protected internal void AddPoints(int points)
    {
      this.points += points;
    }

    internal int getCostByCategory(Category category)
    {
      int result = 0;
      foreach (Product product in this.products)
      {
        if (product.category == category)
        {
          result += product.price;
        }
      }
      // System.Console.WriteLine(result);

      return result;
    }
  }
}