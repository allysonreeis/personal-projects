using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class AddressTest
{
    [Fact]
    public void ShouldInstantiateAddress()
    {
        var address = new Address("Street", "City", "State", "PostalCode", "Country");

        Assert.NotNull(address);
        Assert.NotNull(address.Street);
        Assert.NotNull(address.City);
        Assert.NotNull(address.State);
        Assert.NotNull(address.PostalCode);
        Assert.NotNull(address.Country);
    }

    [Fact]
    public void ShouldNotInstantiateAddressWithoutValues()
    {
        static void act() => new Address("", "", "", "", "");
        var ex = Assert.Throws<Exception>(act);
        Assert.Equal("Street cannot be empty", ex.Message);

        static void act2() => new Address("Street", "", "", "", "");
        var ex2 = Assert.Throws<Exception>(act2);
        Assert.Equal("City cannot be empty", ex2.Message);

        static void act3() => new Address("Street", "City", "", "", "");
        var ex3 = Assert.Throws<Exception>(act3);
        Assert.Equal("State cannot be empty", ex3.Message);

        static void act4() => new Address("Street", "City", "State", "", "");
        var ex4 = Assert.Throws<Exception>(act4);
        Assert.Equal("ZipCode cannot be empty", ex4.Message);

        static void act5() => new Address("Street", "City", "State", "PostalCode", "");
        var ex5 = Assert.Throws<Exception>(act5);
        Assert.Equal("Country cannot be empty", ex5.Message);
    }
}
