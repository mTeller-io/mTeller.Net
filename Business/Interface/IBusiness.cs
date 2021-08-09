using  System.Collections.Generic;
using System;

namespace Business.Interface
{
    public interface IBusiness
    {
         IList<String> GetList( );

         IBusiness Get();
    }
}