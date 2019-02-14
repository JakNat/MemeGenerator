using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Api.Controllers;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Memes;
using Server.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Api.Controllers
{
    public class MemesController : ApiControllerBase
    {
        private readonly IMemeService _memeService;

        public MemesController(IMemeService memeService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _memeService = memeService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                var memes = await _memeService.GetAllAsync();
                return Json(memes);
            }
            var meme =  await _memeService.GetAsync(title);
            return Json(meme);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var meme = await _memeService.GetAllAsync();
        //    return Json(meme);
        //}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMeme command)
        {
            await DispatchAsync(command);

            return Ok();
        }
    }
}
