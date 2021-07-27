using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IValidator<Type>
    {
        Dictionary<string, string> Error { get; set; }
        // This dictionary will contain all error messages

        bool Validate(Type entity);
        // This method will validate an entity
    }
}
