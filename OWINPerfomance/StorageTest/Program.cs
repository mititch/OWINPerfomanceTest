using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace StorageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting.");
            var adapter = new DAL.StorageRepository<Entity>();
            var list = adapter.GetAll("TestPart");
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
