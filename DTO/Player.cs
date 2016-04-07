using Common.Enumerations;

namespace DTO
{
    public class Player
    {
        public int Id { get; set; }

        public int TeamId { get; set; } // foreign key 

        public string Name { get; set; }

        public Status Status { get; set; }

        public Condition Condition { get; set; }

    }
}
