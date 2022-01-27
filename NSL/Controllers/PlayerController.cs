using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSL.Data;
using NSL.IRepository;
using NSL.Models;

namespace NSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IUnitOfWork unitOfWork, ILogger<PlayerController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        //[HttpGet(Name = "GetPlayers")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetPlayers()
        //{
        //    try
        //    {
        //        var players = await _unitOfWork.Players.GetAll();
        //        var results = _mapper.Map<List<PlayerDTO>>(players);
        //        return Ok(players);
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, $"Something went wrong in the {nameof(GetPlayers)}");
        //        return StatusCode(500, "Internal Server Error; Please try again later");
        //    }
        //}

        [HttpGet(Name = "GetPlayers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayers([FromQuery] RequestParams requestParams)
        {            
            var players = await _unitOfWork.Players.GetPagedList(requestParams);
            var results = _mapper.Map<List<PlayerDTO>>(players);
            return Ok(players);            
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetPlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _unitOfWork.Players.Get(p => p.Id == id);
            var results = _mapper.Map<PlayerDTO>(player);
            return Ok(player);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDTO playerDTO)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(GetPlayer)}");
                return BadRequest(ModelState);
            }

            var player = _mapper.Map<Player>(playerDTO);
            await _unitOfWork.Players.Insert(player);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetPlayer", new { id = player.Id }, player);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerDTO playerDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid PUT attempt in { nameof(UpdatePlayer)}");
                return BadRequest(ModelState);
            }

            var player = await _unitOfWork.Players.Get(h => h.Id == id);
            if (player == null)
            {
                _logger.LogError($"Invalid PUT attempt in { nameof(UpdatePlayer)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(playerDTO, player);
            _unitOfWork.Players.Update(player);
            await _unitOfWork.Save();

            return NoContent();
        }


        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in { nameof(DeletePlayer)}");
                return BadRequest();
            }

            var player = await _unitOfWork.Players.Get(h => h.Id == id);
            if (player == null)
            {
                _logger.LogError($"Invalid DELETE attempt in { nameof(DeletePlayer)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Players.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
