using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.CategoryUseCases.Create;
public class CreateCategoryInput
{
    public CreateCategoryInput(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
