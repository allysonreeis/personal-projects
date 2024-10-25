using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Exceptions;
public class DomainValidationException : Exception
{
    public List<string> Errors { get; set; }

    public DomainValidationException(List<string> errors)
    {
        Errors = errors;
    }

    public DomainValidationException(string error)
    {
        Errors = [error];
    }
}
