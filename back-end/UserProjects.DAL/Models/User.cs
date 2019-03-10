namespace UserProjects.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : BaseEntity
    {
         [MaxLength(50)]
         [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        public List<UserProject> UserProjects { get; set; }

    }
}