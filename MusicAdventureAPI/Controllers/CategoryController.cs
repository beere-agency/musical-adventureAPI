using MAService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository category;
        public CategoryController(ICategoryRepository _category)
        {
            category = _category;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
