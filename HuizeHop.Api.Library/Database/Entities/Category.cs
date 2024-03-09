namespace HuizeHop.Api.Library.Database.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public bool IsRecurring { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}