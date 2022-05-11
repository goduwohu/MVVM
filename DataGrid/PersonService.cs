using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.DataGrid
{
    public class PersonService
    {
        public IEnumerable<Person> GetPersons()
        {
            var deps = GetDepartments();
            var engDep = deps[0];
            var salesDep = deps[1];
            var mgmDep = deps[2];

            return new Person[]
            {
                new Person(){ Firstname = "Max", Lastname = "Muster", Email = "max@muster.de", Id = 1, Department = engDep },
                new Person(){ Firstname = "Susi", Lastname = "Müller", Email = "susi@muster.de", Id = 2, Department = salesDep, Birthday = new DateTime (1990, 5, 1) },
                new Person(){ Firstname = "Dave", Lastname = "Dev", Email = "dev.dave@muster.de", Id = 3, Department = engDep, Birthday = new DateTime (1980, 10, 4) },
                new Person(){ Firstname = "Chief", Lastname = "Bossinger", Email = "ceo@muster.de", Id = 4, Department = mgmDep, Birthday = new DateTime (1985, 6, 17) },
            };
        }



        public Department[] GetDepartments()
        {
            return new Department[]
            {
                new Department() { Id = 1, Name = "Engineering" },
                new Department() { Id = 2, Name = "Sales" },
                new Department() { Id = 1, Name = "Management" }
            };
        }
    }
}
