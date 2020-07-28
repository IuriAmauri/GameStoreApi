using System.Collections.Generic;
using GameStoreApi.Models;

namespace GameStoreApi.Data
{
    public interface IGamesRepository
    {
         IEnumerable<Game> GetAllGames();
         Game GetGameById(int id);
         void CreateGame(Game game);
         void UpdateGame(Game game);
         void DeleteGame(Game game);
    }
}