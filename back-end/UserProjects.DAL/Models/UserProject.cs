namespace UserProjects.DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProject
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }
}