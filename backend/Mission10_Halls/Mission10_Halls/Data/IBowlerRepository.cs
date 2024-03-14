namespace Mission10_Halls.Data
{
    public interface IBowlerRepository
    {
       IEnumerable<Bowler> Bowlers { get; }
       IEnumerable<Bowler> GetBowlersWithTeams();

    }
}
