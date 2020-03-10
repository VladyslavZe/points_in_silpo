using System;

namespace SilpoMarket
{
  public class Product
  {
    public int price { get; private set; }
    public String name { get; private set; }
    public Category category;
    public Product(int price, String name, Category category)
    {
      this.price = price;
      this.name = name;
      this.category = category;
    }
    public Product(int price, String name)
    {
      this.price = price;
      this.name = name;
    }
  }
}