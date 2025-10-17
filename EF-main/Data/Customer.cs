using System.ComponentModel.DataAnnotations;

namespace MiniEfApi.Data
{
    public class Customer
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
