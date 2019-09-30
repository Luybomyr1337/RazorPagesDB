using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGrades.ViewModels;
using RazorPagesGrades.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesGrades.Pages.Grade
{
    public class AddModel : PageModel
    {
        private IGradebook gradebook;

        [BindProperty]
        public GradeViewModel Grade { get; set; }

        public List<SelectListItem> AcronymList { get; set; }


        public void OnGet()
        {
            
        }
    }
}