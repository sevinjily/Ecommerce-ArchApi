﻿using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDAL _brandDAL;
        private readonly IMapper _mapper;
        public BrandManager(IBrandDAL brandDAL, IMapper mapper)
        {
            _brandDAL = brandDAL;
            _mapper = mapper;
        }

        public IResult Create(AddBrandDTO model)
        {
            var map=_mapper.Map<Brand>(model);
            map.CreatedDate = DateTime.Now;
            _brandDAL.Add(map); 
            return new SuccessResult(System.Net.HttpStatusCode.OK);
        }

        public IResult Update(UpdateBrandDTO model)
        {
            //var findBrand = _brandDAL.Get(x=>x.Id==Guid.Parse(model.Id);
            var map = _mapper.Map<Brand>(model);
            _brandDAL.Update(map);
            return new SuccessResult(System.Net.HttpStatusCode.OK);
        }
    }
}
