namespace MiniEfApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Road { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
