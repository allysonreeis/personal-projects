namespace ByteShop.ECommerce.Domain.Entities;
public class Address : IEquatable<Address>
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string postalCode, string country)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Street)) throw new Exception("Street cannot be empty");
        if (string.IsNullOrWhiteSpace(City)) throw new Exception("City cannot be empty");
        if (string.IsNullOrWhiteSpace(State)) throw new Exception("State cannot be empty");
        if (string.IsNullOrWhiteSpace(PostalCode)) throw new Exception("ZipCode cannot be empty");
        if (string.IsNullOrWhiteSpace(Country)) throw new Exception("Country cannot be empty");
    }

    public bool Equals(Address? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Street == other.Street && City == other.City && State == other.State && PostalCode == other.PostalCode && Country == other.Country;
    }

    public override bool Equals(object? obj)
    {
        return obj is Address address && Equals(address);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, State, PostalCode, Country);
    }
}
