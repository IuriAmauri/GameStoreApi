using System.Collections.Generic;
using System.Linq;
using GameStoreApi.Models;

namespace GameStoreApi.Data
{
    public class SqlGamesRepository : IGamesRepository
    {
        private readonly GameDbContext _dbContext;
        public SqlGamesRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Game GetGameById(int id)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _dbContext.Games.ToList();
        }

        public void CreateGame(Game game)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateGame(Game game)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteGame(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}