using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int PositionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Desc { get; set; }
        public Position Position { get; set; }
        

    }
}
