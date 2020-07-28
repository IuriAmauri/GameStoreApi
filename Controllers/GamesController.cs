using System.Collections.Generic;
using GameStoreApi.Data;
using GameStoreApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gameRepository;
        public GamesController(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
        {
            var result = _gameRepository.GetAllGames();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}