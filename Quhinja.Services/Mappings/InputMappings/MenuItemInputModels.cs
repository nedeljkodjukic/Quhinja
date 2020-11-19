using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
    public class MenuItemInputModels : Profile
    {
        public MenuItemInputModels()
        {
            CreateMap<MenuItemBasicInputModel,MenuItem>();
            CreateMap<MissedLunchBasicInputModel, MissedLunch>();
        }
    
    }
}
