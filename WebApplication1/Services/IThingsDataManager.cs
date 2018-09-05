using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    using WebApplication1.Models;

    public interface IThingsDataManager
    {
        IEnumerable<Thing> GetAll();

        void Create(Thing thing);

        void Update(Thing thing);

        void Delete(int number);
    }
}
