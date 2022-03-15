using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IDataResult<int> Add(Book book)
        {
            return new SuccessDataResult<int>(_bookDal.Add(book),Messages.BookAddMessage);
        }
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdateMessage);
        }
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleteMessage);
        }
        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == bookId));
        }
        public IDataResult<List<Book>> GetList()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList().ToList());
        }
        public IDataResult<int> GetCount(string filter = null)
        {
            return filter == null
                ? new SuccessDataResult<int>(_bookDal.GetCount(default))
                : new SuccessDataResult<int>(_bookDal.GetCount(b => b.Title.Contains(filter) || b.Author.Contains(filter)));
        }
        public IDataResult<List<Book>> GetList(string filter = null, int? page = null, int? count = null)
        {
            return filter != null ?
                new SuccessDataResult<List<Book>>(_bookDal.GetList(b => b.Title.Contains(filter) || b.Author.Contains(filter), page, count).ToList()) :
                new SuccessDataResult<List<Book>>(_bookDal.GetList(default, page, count).ToList());
        }
        public IDataResult<List<Book>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList(b => b.CategoryId == categoryId).ToList());
        }
        public IDataResult<List<Book>> GetFilter(List<string> filter = null, int? page = null, int? count = null)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetFilter(filter, page, count).ToList());
        }


    }
}
