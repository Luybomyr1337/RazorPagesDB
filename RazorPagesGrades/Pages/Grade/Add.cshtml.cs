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

        public AddModel(ISubjectManipulator subj, IGradebook gradebook)
        {
            AcronymList = subj.SubjectListItems;
            this.gradebook = gradebook;
        }

        [TempData]
        public string MessageSuccess { get; set; }

        [TempData]
        public string MessageError { get; set; }

        [BindProperty]
        public GradeViewModel Grade { get; set; }

        public List<SelectListItem> AcronymList { get; set; }

        public List<SelectListItem> WeightList { get; } = new List<SelectListItem>()
        {
            new SelectListItem("A (10)", "10"),
            new SelectListItem("B (9)", "9"),
            new SelectListItem("C (8)", "8"),
            new SelectListItem("D (7)", "7"),
            new SelectListItem("E (6)", "6"),
            new SelectListItem("F (5)", "5", true),
            new SelectListItem("G (4)", "4"),
            new SelectListItem("H (3)", "3"),
            new SelectListItem("I (2)", "2"),
            new SelectListItem("J (1)", "1")
        };

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (gradebook.AddGrade(Grade.Acronym, Grade.Value, Grade.Weight))
                MessageSuccess = "Grade saved (" + Grade.Acronym + ")";
            else
                MessageError = "Grade don't created. Subject " + Grade.Acronym + " missing!";

            return RedirectToPage("./Index");
        }
    }
}