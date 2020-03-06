using System;
using System.Collections.Generic;


namespace SilpoMarket
{
  public class Check
  {
    public List<Product> products { get; set; }
    public int totalCost { get; set; }

    public int getTotalCost()
    {
      return totalCost;
    }
  }
}