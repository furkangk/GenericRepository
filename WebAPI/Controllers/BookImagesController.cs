using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        private IBookImageService _bookImageService;
        private IWebHostEnvironment _enviroment;

        public BookImagesController(IBookImageService bookImageService,IWebHostEnvironment environment)
        {
            _bookImageService = bookImageService;
            _enviroment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _bookImageService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getlistbybook")]
        public IActionResult GetListByBook(int bookId)
        {
            var result = _bookImageService.GetListByBook(bookId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _bookImageService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(BookImage bookImage)
        {
            var result = _bookImageService.Add(bookImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(BookImage bookImage)
        {
            var result = _bookImageService.Update(bookImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookImage bookImage)
        {
            var resultbook=_bookImageService.GetListByBook(bookImage.BookId);
            List<BookImage> book =resultbook.Data;
            UploadsController uploads = new UploadsController(_enviroment);
            foreach (var item in book)
            {
                var uploadResult = uploads.DeleteUploads(item.Name);
                if (!uploadResult.Success)
                {
                    return BadRequest(uploadResult.Message);
                }
            }
            var result = _bookImageService.Delete(book);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
