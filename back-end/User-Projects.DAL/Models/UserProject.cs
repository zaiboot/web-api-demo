namespace UserProjects.DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProject : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }

    }
}