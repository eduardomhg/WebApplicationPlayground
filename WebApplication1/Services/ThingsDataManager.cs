using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    using WebApplication1.Models;

    public class ThingsDataManager : IThingsDataManager
    {
        public List<Thing> Things { get; private set; }

        public ThingsDataManager()
        {
            Things = new List<Thing>();
            Things.Add(new Thing { Number = 1, Text = "Holaaa" });
            Things.Add(new Thing { Number = 2, Text = "Adios" });
            Things.Add(new Thing { Number = 3, Text = "Holaaa" });
            Things.Add(new Thing { Number = 4, Text = "Adios" });
            Things.Add(new Thing { Number = 5, Text = "Holaaa" });
            Things.Add(new Thing { Number = 6, Text = "Adios" });
            Things.Add(new Thing { Number = 7, Text = "Holaaa" });
            Things.Add(new Thing { Number = 8, Text = "Adios" });
        }

        public IEnumerable<Thing> GetAll()
        {
            return Things;
        }

        public void Create(Thing thing)
        {
            Things.Add(thing);
        }

        public void Update(Thing thing)
        {
            var thingToEdit = Things.FirstOrDefault(t => t.Number == thing.Number);

            if (thingToEdit != null)
            {
                thingToEdit.Text = thing.Text;
            }
        }

        public void Delete(int number)
        {
            Things.Remove(Things.FirstOrDefault(t => t.Number == number));
        }
    }
}
