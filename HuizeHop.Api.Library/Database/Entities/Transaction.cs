namespace HuizeHop.Api.Library.Database.Entities
{
    public class Transaction : BaseEntity
    {
        public DateTime Moment { get; set; }
        public required string Account { get; set; }
        public string? Iban { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public Guid CategoryID { get; set; }
    }
}