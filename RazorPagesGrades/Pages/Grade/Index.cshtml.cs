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
        public IndexModel(IGradebook gb)
        {
            Grades = new List<GradeViewModel>();
            _gradebook = gb;
        }

        [TempData]
        public string MessageSuccess { get; set; }
        [TempData]
        public string MessageError { get; set; }

        public List<GradeViewModel> Grades { get; set; }

        public void OnGet()
        {
            Grades = new List<GradeViewModel>();

            foreach (var grade in _gradebook.GetAllGrades())
            {
                Grades.Add(new GradeViewModel() { Id = grade.Id, Subject = grade.Subject.Name, Acronym = grade.Subject.Acronym, Value = grade.Value, Weight = grade.Weight });
            }
        }

        public IActionResult OnGetRemove(Guid id)
        {
            if (_gradebook.RemoveGrade(id)) 
                MessageSuccess += "Record removed successfully (" + id + ")";

            return RedirectToPage("./Index");
        }
    }
}