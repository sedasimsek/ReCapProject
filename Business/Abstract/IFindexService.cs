using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindexService 
    {
        IDataResult<List<Findex>> GetAllByUserId(int UserId);
        IResult Add(Findex findex);
        IResult Delete(Findex findex);
        IResult Update(Findex findex);
        IDataResult<List<Findex>> GetAll();
        IDataResult<Findex> GetById(int Id);
    }
}
