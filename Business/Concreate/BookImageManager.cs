using Business.Abstract;
using Business.Contants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;

        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }
        public IResult Add(BookImage bookImage)
        {
            _bookImageDal.Add(bookImage);
            return new SuccessResult(Messages.BookImageAddMessage);
        }
        [TransactionScopeAspect]
        public IResult Delete(List<BookImage> bookImage)
        {
            for (int i = 0; i < bookImage.Count; i++)
            {
                _bookImageDal.Delete(bookImage[i]);
            }
            return new SuccessResult(Messages.BookImageDeleteMessage);
        }

        public IDataResult<BookImage> GetById(int imageId)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(b => b.Id == imageId));
        }

        public IDataResult<List<BookImage>> GetList(string filter = null)
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetList().ToList());
        }

        public IDataResult<List<BookImage>> GetListByBook(int bookId)
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetList(b => b.BookId == bookId).ToList());
        }

        public IResult Update(BookImage bookImage)
        {
            _bookImageDal.Update(bookImage);
            return new SuccessResult(Messages.BookImageUpdateMessage);
        }
    }
}
