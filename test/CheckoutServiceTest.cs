using System;
using Xunit;
using SilpoMarket;

namespace SilpoTest
{
  public class CheckoutServiceTest
  {
    private CheckoutService _checkoutService;
    private Product _milk_7;
    private Product _bread_3;
    public CheckoutServiceTest()
    {
      _checkoutService = new CheckoutService();
      _checkoutService.OpenCheck();
      _milk_7 = new Product(7, "Milk");
      _bread_3 = new Product(3, "Bread");

    }
    [Fact]
    void closeCheck__withOneProduct()
    {
      _checkoutService.AddProduct(_milk_7);
      Check check = _checkoutService.CloseCheck();
      // check.AddProduct((new Product(7, "Milk")));

      Assert.Equal(7, check.GetTotalCost());
    }

    [Fact]
    void closeCheck__withTwoProducts()
    {
      _checkoutService.AddProduct(_milk_7);
      _checkoutService.AddProduct(_bread_3);
      Check check = _checkoutService.CloseCheck();

      Assert.Equal(10, check.GetTotalCost());
    }

    [Fact]
    void addProduct__whenCheckIsClosed__opensNewCheck()
    {
      _checkoutService.AddProduct(_milk_7);
      Check milkCheck = _checkoutService.CloseCheck();
      Assert.Equal(7, milkCheck.GetTotalCost());

      _checkoutService.AddProduct(_bread_3);
      Check breadCheck = _checkoutService.CloseCheck();
      Assert.Equal(3, breadCheck.GetTotalCost());

    }

    [Fact]
    void closeCheck__calcTotalPoints()
    {
      _checkoutService.AddProduct(_milk_7);
      _checkoutService.AddProduct(_bread_3);
      Check check = _checkoutService.CloseCheck();

      Assert.Equal(10, check.GetTotalPoints());
    }

    [Fact]
    void useOffer__addOfferPoints()
    {
      _checkoutService.AddProduct(_milk_7);
      _checkoutService.AddProduct(_bread_3);

      _checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
      Check check = _checkoutService.CloseCheck();

      Assert.Equal(12, check.GetTotalPoints());
    }

    [Fact]
    void useOffer__whenCostLessThanRequired__doNothing()
    {
      _checkoutService.AddProduct(_bread_3);

      _checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
      Check check = _checkoutService.CloseCheck();

      Assert.Equal(3, check.GetTotalPoints());
    }
  }
}