using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class CustomerTest
{
    [Fact]
    public void ShouldInstantiateCustomer()
    {
        var address = new Address("Street", "City", "State", "PostalCode", "Country");
        var customer = new Customer("Name", "email@mail.com", address);

        Assert.NotNull(customer);
        Assert.NotEqual(Guid.Empty, customer.Id);
        Assert.NotNull(customer.Name);
        Assert.NotNull(customer.Email);
        Assert.NotNull(customer.Address);
        Assert.NotNull(customer.Address.City);
        Assert.NotNull(customer.Address.State);
        Assert.NotNull(customer.Address.PostalCode);
        Assert.NotNull(customer.Address.Country);

    }

    [Fact]
    public void ShouldNotInstantiateCustomerWithoutAddress()
    {
        static void act() => new Customer("Name", "email@email.com", null);
        var ex = Assert.Throws<Exception>(act);
        Assert.Equal("Address should not be null", ex.Message);
    }

    [Fact]
    public void ShouldNotInstantiateCustomerWithInvalidValues()
    {
        static void act() => new Customer("", "", null);
        var ex = Assert.Throws<Exception>(act);
        Assert.Equal("Name is required", ex.Message);

        static void act2() => new Customer("Name", "", null);
        var ex2 = Assert.Throws<Exception>(act2);
        Assert.Equal("Email is required", ex2.Message);

        var address = new Address("Street", "City", "State", "PostalCode", "Country");
        void action() => new Customer("Name", "invalidemail", address);
        var ex3 = Assert.Throws<Exception>(action);
        Assert.Equal("Email is invalid", ex3.Message);
    }
}
