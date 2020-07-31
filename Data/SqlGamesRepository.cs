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

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _dbContext.Games.ToList();
        }

        public Game GetGameById(int id)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public void CreateGame(Game game)
        {
            _dbContext.Games.Add(game);
        }

        public void UpdateGame(Game game)
        {
            _dbContext.Update(game);
        }

        public void DeleteGame(Game game)
        {
            _dbContext.Remove(game);
        }
    }
}