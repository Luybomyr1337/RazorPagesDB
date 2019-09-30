using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGrades.Services;
using RazorPagesGrades.ViewModels;

namespace RazorPagesGrades.Pages.Grade
{
    public class IndexModel : PageModel
    {
        IGradebook _gradebook;
        public IndexModel()
        {
            Grades = new List<GradeViewModel>();
        }

        public List<GradeViewModel> Grades { get; set; }

        public void OnGet()
        {

        }

    }
}