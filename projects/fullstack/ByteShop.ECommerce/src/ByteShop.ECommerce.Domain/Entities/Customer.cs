using ByteShop.ECommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Entities;

public class Customer
{
    //private static readonly string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, string email, Address address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Address = address;
        Validate();
    }

    private void Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Name))
            errors.Add("Name is required");

        if (string.IsNullOrWhiteSpace(Email))
            errors.Add("Email is required");

        if (!EmailRegex.IsMatch(Email))
            errors.Add("Email is invalid");

        if (Address is null)
            errors.Add($"{nameof(Address)} should not be null");

        if (errors.Any())
            throw new DomainValidationException(errors);
    }
}
