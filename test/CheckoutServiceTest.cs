using System;
using Xunit;
using SilpoMarket;

namespace SilpoTest
{
  public class CheckoutServiceTest
  {
    private CheckoutService _checkoutService;
    public CheckoutServiceTest()
    {
      _checkoutService = new CheckoutService();
    }
    [Fact]
    void closeCheck__withOneProduct()
    {
      _checkoutService.OpenCheck();

      _checkoutService.AddProduct(new Product(7, "Milk"));
      Check check = _checkoutService.CloseCheck();
      // check.AddProduct((new Product(7, "Milk"));

      Assert.Equal(7, check.GetTotalCost());
    }

    [Fact]
    void closeCheck__withTwoProducts()
    {
      _checkoutService.OpenCheck();

      _checkoutService.AddProduct(new Product(7, "Milk"));
      _checkoutService.AddProduct(new Product(3, "Bred"));

      Check check = _checkoutService.CloseCheck();

      Assert.Equal(10, check.GetTotalCost());
    }
  }
}