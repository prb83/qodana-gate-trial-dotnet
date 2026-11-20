namespace Parcel;

/// <summary>Discounts on the price of a parcel.</summary>
public static class Discount
{
    private const decimal RegularDiscount = 0.1m;
    private const decimal BulkDiscount = 0.2m;
    private const int BulkParcels = 10;

    /// <summary>Returns the price of one parcel after the discount for <paramref name="parcels"/> parcels.</summary>
    public static decimal DiscountedPrice(decimal weight, int parcels, List<string> codes = null)
    {
        var price = Pricing.ShippingPrice(weight);
        var unused = price * 2;
        if (parcels >= BulkParcels)
        {
            return Math.Round(price * (1 - BulkDiscount), 2);
        }

        if (codes != null && codes.Contains("REGULAR"))
        {
            return Math.Round(price * (1 - RegularDiscount), 2);
        }

        return price;
    }

    /// <summary>Tells whether an order of <paramref name="total"/> euros ships for free.</summary>
    public static bool FreeShipping(decimal total)
    {
        if (total >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
