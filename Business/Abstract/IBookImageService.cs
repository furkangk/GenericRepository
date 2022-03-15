using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IDataResult<BookImage> GetById(int imageId);
        IDataResult<List<BookImage>> GetList(string filter = null);
        IDataResult<List<BookImage>> GetListByBook(int bookId);
        IResult Add(BookImage bookImage);
        IResult Delete(List<BookImage> bookImage);
        IResult Update(BookImage bookImage);
    }
}
