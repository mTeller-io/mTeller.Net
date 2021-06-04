using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    interface IMtellerProccessor<T> where T : class
    {
        void Create(T Tdata);
        void Delete(T Tdata);
        void Update(T Tdata);
        IEnumerable<T> Load();
    }
}
