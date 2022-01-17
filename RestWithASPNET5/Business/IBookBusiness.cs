using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll(); 
        BookVO FindById(long id);
        BookVO Create(BookResumeVO book);
        BookVO Update(long id, BookResumeVO book);
        void Delete(long id);
        public List<BookVO> FindByTitle(string title);
        public List<BookVO> FindByAuthor(string author);
        public List<BookVO> FindByLaunchDate(DateTime dateTime);
        public List<BookVO> FindByPrice(decimal price);
    }
}
