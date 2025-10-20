using System.ComponentModel.DataAnnotations;
using EF_ENTITY.Entities.Base;
namespace MiniEfApi.Entities
{
    public class Customer: EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
    