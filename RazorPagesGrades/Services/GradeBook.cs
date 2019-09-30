using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesGrades.Models;

namespace RazorPagesGrades.Services
{
    public class GradeBook : IGradebook, ISubjectManipulator, IGradeManipulator
    {
        /// <summary>
        ///   Řešení úschovy (částečně) persistentních dat
        ///   <Akronym, Předmět>
        /// </summary>
        private SortedDictionary<string, Subject> _subjects { get; set; } = new SortedDictionary<string, Subject>();

        public Dictionary<Guid, Grade> _grades { get; set; } = new Dictionary<Guid, Grade>();

        public List<SelectListItem> SubjectListItems
        {
            get
            {
                var list = new List<SelectListItem>(_subjects.Select(x => { return new SelectListItem() { Value = x.Key, Text = x.Key + " (" + x.Value.Name + ")" }; }));
                
                return list;
            }
        }

        private static readonly Random random = new Random();

        public void SeedSubjects()
        {
            _subjects.TryAdd("MAT", new Subject { Acronym = "MAT", Name = "Matematika" });
            _subjects.TryAdd("PRG", new Subject { Acronym = "PRG", Name = "Programování" });
            _subjects.TryAdd("WEB", new Subject { Acronym = "WEB", Name = "Webové aplikace" });
            _subjects.TryAdd("TEV", new Subject { Acronym = "TEV", Name = "Tělocvik" });
            _subjects.TryAdd("CJL", new Subject { Acronym = "CJL", Name = "Český jazyk a literatura" });
            _subjects.TryAdd("ANJ", new Subject { Acronym = "ANJ", Name = "Anglický jazyk" });
        }

        public void SeedGrades(int count)
        {
            SeedSubjects();

            for (int i = 0; i < count; i++)
            {
                var subject = _subjects.ElementAt(random.Next(0, _subjects.Count)).Value;
                var grade = new Grade() { Id = Guid.NewGuid(), Subject = subject, Value = random.Next(2, 11) * 0.5, Weight = random.Next(1, 11) };
                _grades.TryAdd(grade.Id, grade);
            }
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _grades.Values;
        }

        public IEnumerable<Grade> GetGrades(string subjectAcronym)
        {
            return _grades.Values.Where(g => g.Subject.Acronym.Contains(subjectAcronym.ToUpper()));
        }

        public bool AddGrade(string acronym, double value, int weight)
        {
            if (!_subjects.ContainsKey(acronym)) return false;

            var grade = GradeCreate(acronym, value, weight);
            return _grades.TryAdd(grade.Id, grade);
        }

        public bool AddGrade(Grade grade)
        {
            return _grades.TryAdd(grade.Id, grade);
        }

        public bool RemoveGrade(Guid id)
        {
            return _grades.Remove(id);
        }

        public Grade GradeCreate(string acronym, double value, int weight)
        {
            if (!_subjects.ContainsKey(acronym)) throw new KeyNotFoundException("Subject with Acronym " + acronym + " not found.");

            return new Grade() { Id = Guid.NewGuid(), Subject = _subjects[acronym], Value = value, Weight = weight };
        }
    }
}
