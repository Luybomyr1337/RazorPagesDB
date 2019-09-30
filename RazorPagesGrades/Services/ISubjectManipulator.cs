using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesGrades.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RazorPagesGrades.Services
{
    public interface ISubjectManipulator
    {
        void SeedSubjects();

        List<SelectListItem> SubjectListItems { get; }
    }
}
