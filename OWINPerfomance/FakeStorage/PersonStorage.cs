using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStorage
{
    public class PersonStorage
    {
        private static readonly Lazy<PersonStorage> _instance = new Lazy<PersonStorage>(() => new PersonStorage());

        public object Locker = new object();

        public static PersonStorage Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IList<Person> Persons { get; set; }

        private PersonStorage()
        {
            this.Persons = new List<Person>{
                new Person {Name="First", Id = 1},
                new Person {Name="Second", Id = 2}
            };
        }
    }
}
