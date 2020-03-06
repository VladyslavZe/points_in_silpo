using System;

namespace SilpoMarket
{
  public class Product
  {
    public int price { get; private set; }
    public String name { get; private set; }
    public Product(int price, String name)
    {
      this.price = price;
      this.name = name;
    }

  }
}