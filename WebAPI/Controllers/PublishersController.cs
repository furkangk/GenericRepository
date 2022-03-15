using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Authorization;
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
    public class PublishersController : ControllerBase
    {

        private IPublisherService _publisherService;
        private IWebHostEnvironment _enviroment;

        public PublishersController(IPublisherService publisherService,IWebHostEnvironment environment)
        {
            _publisherService = publisherService;
            _enviroment = environment;
        }
        [HttpGet("getall")]

        public IActionResult GetList(string? filter, int? page, int? count)

        {
            var result = _publisherService.GetList(filter, page, count);
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
            var result = _publisherService.GetFilter(filter, page, count);
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
            var result = _publisherService.GetCount(filter);
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
            var result = _publisherService.GetById(id);
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
        public IActionResult Add(Publisher publisher)
        {
            var result = _publisherService.Add(publisher);
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
        public IActionResult Update(Publisher publisher)
        {
            var result = _publisherService.Update(publisher);
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
        public IActionResult Delete(Publisher publisher)
        {
            var getPublisher = _publisherService .GetById(publisher.Id);
            UploadsController uploads = new UploadsController(_enviroment);
            var uploadResult = uploads.DeleteUploads(getPublisher.Data.Logo);
            if (!uploadResult.Success)
            {
                return BadRequest(uploadResult.Message);
            }
            var result = _publisherService.Delete(publisher);
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
