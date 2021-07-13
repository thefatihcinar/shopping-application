using AutoMapper;
using ShopApp.Entities;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductViewModel, Product>(); // ProductVM -> Product
        }
    }
}
