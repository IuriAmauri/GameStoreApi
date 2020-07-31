using System.Collections.Generic;
using AutoMapper;
using GameStoreApi.Data;
using GameStoreApi.Dtos;
using GameStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IMapper _mapper;
        public GamesController(IGamesRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
        {
            var result = _gameRepository.GetAllGames();

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<GameReadDto>>(result));
        }

        [HttpGet("{id}", Name="GetGameById")]
        public ActionResult<GameReadDto> GetGameById(int id)
        {
            var result = _gameRepository.GetGameById(id);

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<GameReadDto>(result));
        }

        [HttpPost]
        public ActionResult<GameReadDto> CreateGame(GameCreateDto gameCreateDto)
        {
            var gameModel = _mapper.Map<Game>(gameCreateDto);
            _gameRepository.CreateGame(gameModel);
            _gameRepository.SaveChanges();
            
            var commandReadDto = _mapper.Map<GameReadDto>(gameModel);

            return CreatedAtRoute(nameof(GetGameById), new {Id = gameModel.Id}, _mapper.Map<GameReadDto>(gameModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, GameUpdateDto gameUpdateDto)
        {
            var game = _gameRepository.GetGameById(id);

            if (game == null)
                return NotFound();

            _mapper.Map(gameUpdateDto, game);
            
            _gameRepository.UpdateGame(game);
            _gameRepository.SaveChanges();
            
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchCommand(int id, JsonPatchDocument<GameUpdateDto> patchDocument)
        {
            var game = _gameRepository.GetGameById(id);

            if (game == null)
                return NotFound();

            var gameToPatch = _mapper.Map<GameUpdateDto>(game);
            patchDocument.ApplyTo(gameToPatch, ModelState);

            if (!TryValidateModel(gameToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(gameToPatch, game);

            _gameRepository.UpdateGame(game);
            _gameRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult GameCommand(int id)
        {
            var game = _gameRepository.GetGameById(id);

            if (game == null)
                return NotFound();

            _gameRepository.DeleteGame(game);
            
            return NoContent();
        }
    }
}