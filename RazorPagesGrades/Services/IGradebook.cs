using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesGrades.Models;

namespace RazorPagesGrades.Services
{
    public interface IGradebook
    {
        IEnumerable<Grade> GetAllGrades();
        IEnumerable<Grade> GetGrades(string subjectAcronym);
        bool AddGrade(string acronym, double value, int weight);
        bool AddGrade(Grade grade);
        bool RemoveGrade(Guid id);
    }
}
