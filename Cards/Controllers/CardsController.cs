using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardDomain;
using Cards.Application.Services.Interfaces;
using Cards.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IFileService _fileService;

        public CardsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("get={Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var response = await _fileService.Get(Id);
            return Ok(response);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(Card card)
        {
            await _fileService.Post(card);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(DeleteCard deleteCard)
        {
            _fileService.Delete(deleteCard.Id);
            return Ok();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _fileService.GetAll();
            return Ok(response);
        }

        [HttpPost("delete-by-id")]
        public IActionResult DeleteByid(List<Guid> Ids)
        {
            _fileService.DeleteById(Ids);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Card card)
        {
            await _fileService.Update(card);
            return Ok();
        }
    }
}
