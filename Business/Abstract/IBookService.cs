using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<Book> GetById(int bookId);

        IDataResult<List<Book>> GetList(string filter = null, int? page = null, int? count = null);
        IDataResult<List<Book>> GetFilter(List<string> filter = null, int? page = null, int? count = null);

        IDataResult<int> GetCount(string filter = null);
        IDataResult<List<Book>> GetListByCategory(int categoryId);
        IDataResult<int> Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
    }
}
