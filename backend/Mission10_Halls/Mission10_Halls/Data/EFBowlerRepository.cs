using Microsoft.EntityFrameworkCore;

namespace Mission10_Halls.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlingLeagueContext _bowlerContext;
        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _bowlerContext = temp;
        }
        public IEnumerable<Bowler> Bowlers => _bowlerContext.Bowlers;

        public IEnumerable<Bowler> GetBowlersWithTeams()
        {
            return _bowlerContext.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .ToList();
        }
    }
}
