using Xunit;

namespace Parcel.Tests;

public class DiscountTests
{
    [Fact]
    public void BulkDiscount()
    {
        Assert.Equal(5.52m, Discount.DiscountedPrice(2, parcels: 10));
    }

    [Fact]
    public void NoDiscount()
    {
        Assert.Equal(6.9m, Discount.DiscountedPrice(2, parcels: 1));
    }
}
