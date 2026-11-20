using Xunit;

namespace Parcel.Tests;

public class PricingTests
{
    [Fact]
    public void StandardPrice()
    {
        Assert.Equal(6.9m, Pricing.ShippingPrice(2));
    }

    [Fact]
    public void ExpressPrice()
    {
        Assert.Equal(10.35m, Pricing.ShippingPrice(2, express: true));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WeightMustBeAboveZero(int weight)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Pricing.ShippingPrice(weight));
    }

    [Fact]
    public void WeightHasAMaximum()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Pricing.ShippingPrice(30.1m));
    }

    [Fact]
    public void CheapestOfSeveralParcels()
    {
        Assert.Equal(5.7m, Pricing.Cheapest(new[] { 5m, 1m, 3m }));
    }

    [Fact]
    public void CheapestNeedsAParcel()
    {
        Assert.Throws<ArgumentException>(() => Pricing.Cheapest(Array.Empty<decimal>()));
    }
}
