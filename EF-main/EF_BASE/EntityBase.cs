using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_ENTITY.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ===== Audit fields =====
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

        // ===== Soft delete =====
        public bool IsDeleted { get; set; } = false;

        // ===== Common methods =====
        public void MarkAsDeleted(string? user = null)
        {
            IsDeleted = true;
            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = user;
        }

        public void UpdateAudit(string? user = null)
        {
            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = user;
        }
    }
}
