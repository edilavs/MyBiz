using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;

        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.TeamMembers.Include(x=>x.Position).ToList();
            return View(data);
        }
    }
}
