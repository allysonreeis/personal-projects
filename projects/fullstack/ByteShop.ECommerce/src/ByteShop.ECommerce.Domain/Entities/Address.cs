namespace ByteShop.ECommerce.Domain.Entities;
public class Address
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
}
