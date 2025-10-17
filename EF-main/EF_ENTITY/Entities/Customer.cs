using System.ComponentModel.DataAnnotations;
using EF_ENTITY.Entities.Base;
namespace MiniEfApi.Data
{
    public class Customer: EntityBase
    {
        [Key] 
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
    