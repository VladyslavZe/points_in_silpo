using System;
using Xunit;
using SilpoMarket;

namespace SilpoTest
{
  public class CheckoutServiceTest
  {

    [Fact]
    void AddProduct()
    {
      CheckoutService checkoutService = new CheckoutService();
      checkoutService.openCheck();

      checkoutService.addProduct(new Product(7, "Milk"));
      Check check = checkoutService.closeCheck();

      Assert.Equal(check.getTotalCost(), 7);
    }
  }
}