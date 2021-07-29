using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Identity
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
        /* full name of the user */
    }
}
