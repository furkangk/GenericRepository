using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IWebHostEnvironment _enviroment;
        public CategoriesController(ICategoryService categoryService,IWebHostEnvironment environment)
        {
            _categoryService = categoryService;
            _enviroment = environment;
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getall")]

        public IActionResult GetList(string? filter, int? page, int? count)

        {
            var result = _categoryService.GetList(filter, page, count);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("getfilter")]
        public IActionResult GetFilter(List<string> filter, int? page, int? count)
        {
            var result = _categoryService.GetFilter(filter, page, count);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getcount")]
        public IActionResult GetCount(string filter=null)

        {
            var result = _categoryService.GetCount(filter);
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
        public IActionResult GetById(int id)

        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("getfilter")]
        public IActionResult GetById(List<string> filter, int? page = null, int? count = null)
        {
            var result = _categoryService.GetFilter(filter,page,count);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
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
        public IActionResult Delete(Category category)
        {
            var getCategory = _categoryService.GetById(category.Id);
            UploadsController uploads = new UploadsController(_enviroment);
            var upluadResult = uploads.DeleteUploads(getCategory.Data.Image);
            if (!upluadResult.Success)
            {
                return BadRequest(upluadResult.Message);
            }
            var result = _categoryService.Delete(category);
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
