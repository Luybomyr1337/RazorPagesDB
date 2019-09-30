using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGrades.Services;
using RazorPagesGrades.ViewModels;

namespace RazorPagesGrades.Pages
{
    public class IndexModel : PageModel
    {
        IGradebook _gradebook;
        public IndexModel(IGradebook gb)
        {
            _gradebook = gb;
        }

        public List<GradeViewModel> Grades { get; set; }

        [BindProperty(SupportsGet = true, Name = "q")]
        public string SearchString { get; set; }

        public void OnGet()
        {
            //https://docs.microsoft.com/cs-cz/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-3.0

            Grades = new List<GradeViewModel>();

            if (SearchString?.Length > 0)
            {
                foreach (var grade in _gradebook.GetGrades(SearchString))
                {
                    Grades.Add(new GradeViewModel() { Id = grade.Id, Subject = grade.Subject.Name, Acronym = grade.Subject.Acronym, Value = grade.Value, Weight = grade.Weight });
                }
            } else
            {
                foreach (var grade in _gradebook.GetAllGrades())
                {
                    Grades.Add(new GradeViewModel() { Id = grade.Id, Subject = grade.Subject.Name, Acronym = grade.Subject.Acronym, Value = grade.Value, Weight = grade.Weight });
                }
            }

            

            
        }
    }
}
