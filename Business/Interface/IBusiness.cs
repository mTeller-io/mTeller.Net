using System;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IBusiness
    {
        IList<String> GetList();

        IBusiness Get();
    }
}