using AutoMapper;
using GameStoreApi.Dtos;
using GameStoreApi.Models;

namespace GameStoreApi.Profilers
{
    public class GamesProfiler: Profile
    {
        public GamesProfiler()
        {
            CreateMap<Game, GameReadDto>().ReverseMap();
            CreateMap<Game, GameCreateDto>().ReverseMap();
            CreateMap<Game, GameUpdateDto>().ReverseMap();
        }
    }
}