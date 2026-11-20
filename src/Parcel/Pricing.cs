namespace Parcel;

/// <summary>Prices for sending a parcel.</summary>
public static class Pricing
{
    private const decimal BasePrice = 4.5m;
    private const decimal PricePerKilogram = 1.2m;
    private const decimal ExpressFactor = 1.5m;
    private const decimal MaximumWeight = 30m;

    /// <summary>Returns the price for a parcel of <paramref name="weight"/> kilograms.</summary>
    public static decimal ShippingPrice(decimal weight, bool express = false)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "The weight must be above zero.");
        }

        if (weight > MaximumWeight)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "The parcel is too heavy.");
        }

        var price = BasePrice + weight * PricePerKilogram;
        if (express)
        {
            price *= ExpressFactor;
        }

        return Math.Round(price, 2);
    }

    /// <summary>Returns the lowest standard price of the parcels.</summary>
    public static decimal Cheapest(IReadOnlyCollection<decimal> weights)
    {
        if (weights.Count == 0)
        {
            throw new ArgumentException("No parcel given.", nameof(weights));
        }

        return weights.Min(weight => ShippingPrice(weight));
    }
}
