using System;

namespace Web.Api.Models
{

    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public bool IsActive { get; set; }
    }

}