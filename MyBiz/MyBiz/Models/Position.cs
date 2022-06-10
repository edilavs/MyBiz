﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Models
{
    [Area("manage")]
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}
