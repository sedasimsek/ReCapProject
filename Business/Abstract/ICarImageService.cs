﻿using Core.Utilities.Results;
using Entitites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}