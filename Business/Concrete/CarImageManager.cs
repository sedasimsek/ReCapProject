using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceted(), 
                CheckIfFileExtension(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            var fileExtension = Path.GetExtension(carImage.ImagePath).ToLower();
            string createPath = ImagePath(carImage.ImageId, fileExtension);
            File.Copy(carImage.ImagePath, createPath);
            carImage.ImagePath = createPath;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarAdded);
        }

        private string ImagePath(int ımageId, string fileExtension)
        {
            string GuidKey = Guid.NewGuid().ToString();
            return FilePaths.ImageFolderPath + GuidKey + fileExtension;
        }

        public IResult Delete(CarImage carImage)
        {
            var imageData = _carImageDal.Get(p => p.ImageId == carImage.ImageId);
            File.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(b => b.ImageId == imageId));
        }

        public IResult List(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceted(), CheckIfFileExtension(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            var fileExtension = Path.GetExtension(carImage.ImagePath).ToLower();
            string createPath = ImagePath(carImage.ImageId, fileExtension);
            File.Copy(carImage.ImagePath, createPath);
            File.Delete(carImage.ImagePath);
            carImage.ImagePath = createPath;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);


        }

        private IResult CheckIfCarImageLimitExceted()
        {
            var result = _carImageDal.GetAll();
            if (result.Count <= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceted);
            }

            return new SuccessResult();
        }

        private IResult CheckIfFileExtension(string path)
        {
            string acceptableExtensions = ".png|.jpeg|.jpg";
            if (String.Compare(Path.GetExtension(path).ToLower(), acceptableExtensions) == 0)
            {
                return new ErrorResult(Messages.IncorrectFileExtension);
            }
            return new SuccessResult();
        }

        
    }
}
