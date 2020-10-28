﻿using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.OutputMappings
{
    public class MenuItemOutputModels : Profile
    {
        public MenuItemOutputModels()
        {
            CreateMap<MenuItem, MenuItemBasicOutputModel>();
        }
    }
}