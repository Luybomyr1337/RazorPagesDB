using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesGrades.Models;

namespace RazorPagesGrades.Services
{
    public interface IGradeManipulator
    {
        void SeedGrades(int count);

        Grade GradeCreate(string acronym, double value, int weight);
    }
}
