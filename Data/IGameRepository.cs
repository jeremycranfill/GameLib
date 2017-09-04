using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public interface IGameRepository
    {
        Task<Game> GetGame(int id, bool includeRelated = true);
        void Add(Game game);
        void Remove(Game game);
    }
}