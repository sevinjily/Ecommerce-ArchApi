﻿using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddBrandDTO,Brand >().ReverseMap();
            CreateMap<UpdateBrandDTO, Brand>().ReverseMap();

        }
    }
}
