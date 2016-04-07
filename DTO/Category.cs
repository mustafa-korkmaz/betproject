using Common.Enumerations;

namespace DTO
{
    public class Category
    {
        public int Id { get; set; }

        public int ParentId { get; set; }  // foreign key 

        public string Name { get; set; }

        public string Desc { get; set; }

        public Status Status { get; set; }

    }
}
