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
        //private SortedDictionary<string, Subject> _subjects { get; set; } = new SortedDictionary<string, Subject>();

        //public Dictionary<Guid, Grade> _grades { get; set; } = new Dictionary<Guid, Grade>();

        public List<SelectListItem> SubjectListItems
        {
            get
            {
                var list = new List<SelectListItem>(_db.Subjects.ToList().Select(x => { return new SelectListItem() { Value = x.Acronym, Text = x.Acronym + " (" + x.Name + ")" }; }));
                
                return list;
            }
        }

        public GradeDbContext _db { get; set; }
        public GradeBook(GradeDbContext db)
        {
            _db = db;
        }
        private static readonly Random random = new Random();

        public void SeedSubjects()
        {
            _db.Subjects.Add(new Subject { Acronym = "MAT", Name = "Matematika" });
            _db.Subjects.Add(new Subject { Acronym = "PRG", Name = "Programování" });
            _db.Subjects.Add(new Subject { Acronym = "WEB", Name = "Webové aplikace" });
            _db.Subjects.Add(new Subject { Acronym = "TEV", Name = "Tělocvik" });
            _db.Subjects.Add(new Subject { Acronym = "CJL", Name = "Český jazyk a literatura" });
            _db.Subjects.Add(new Subject { Acronym = "ANJ", Name = "Anglický jazyk" });
            _db.SaveChanges();
        }

        public void SeedGrades(int count)
        {
            SeedSubjects();

            for (int i = 0; i < count; i++)
            {
                var subject = _db.Subjects.ToList().ElementAt(random.Next(0, 6));
                _db.Grades.Add( new Grade { Id = Guid.NewGuid(), Subject = subject, Value = random.Next(2, 11) * 0.5, Weight = random.Next(1, 11) });
                _db.SaveChanges();
            }
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _db.Grades.ToList();
        }

        public IEnumerable<Grade> GetGrades(string subjectAcronym)
        {
            return _db.Grades.Where(g => g.Subject.Acronym.Contains(subjectAcronym.ToUpper())).ToList();
        }

        public bool AddGrade(string acronym, double value, int weight)
        {
            if (!_db.Subjects.SingleOrDefault(s => s.Acronym.Contains(acronym.ToUpper())) return false;

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
