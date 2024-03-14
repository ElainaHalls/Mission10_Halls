using System.ComponentModel.DataAnnotations;

namespace Mission10_Halls.Data
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }

    }
}
